import math
from math import pi, tan, sin, cos, acos, isnan, isinf
from math import sqrt as sqrtm
from numpy import array, dot, diag, sqrt, linspace, divide
from scipy.linalg import eigvalsh, eigh, inv

Tan = tan
Pi = pi
Sin = sin
Cos = cos
Acos = acos
Sqrtm = sqrtm
Sqrt = sqrt
Array = array
Dot = dot
Diag = diag
Linspace = linspace
Eigvalsh = eigvalsh
Eigh = eigh
Inv = inv
Isnan = isnan
Isinf = isinf

ga = 1.9  # coefficient of restitution
mu = 0.5  # friction coefficient
R = 0.0125  # radius of circular base
rho = 1165  # density
g = 9.807  # gravitational accelleration

NOV = 5  # number of values in error computation and plot for each variable
NORec = 25  # number of rectangles in riemann sum
conditionBounds = [0.2, Pi / 2 - 0.35, 0.1, 0.85, 0.1, 0.9, 0.01, 0.05, 250,
                   2500]  # boundaries for error computation and plot for each variable, as in [crth_min, crth_max, ga_min ...]
errors = 0  # if anything went wrong


def vol(th, interval, crth, ga, mu, R, rho):  # computes one rectangle in the riemann sum for the given conditions
    try:
        m = Pi * R ** 3 * Tan(crth) * 2 * rho  # mass
        i = 1 / 4 * m * (R * Cos(crth)) ** 2 + 1 / 12 * m * (R * Sin(crth)) ** 2  # moment of inertia
        b = ((1 + ga) * m * R * (mu * Cos(th) - Sin(th))) / (i + m * R ** 2 * Sin(th) * (Sin(th) - mu * Cos(th)))
        a = b * R * Sin(th)
        d = - b * i / (m * R * (mu * Cos(th) - Sin(th)))
        c = d * R * Sin(th)
        f = d * (- mu)
        e = f * R * Sin(th)
        A = i * (a + 1) ** 2 / 2 + m * (c ** 2 + e ** 2) / 2
        B = i * b ** 2 / 2 + m / 2 * ((d + 1) ** 2 + f ** 2)
        C = m / 2
        D = i * (a + 1) * b + m * (c * (d + 1) + e * f)
        E = m * e
        F = m * f
        s1 = divide(Array([[A, D / 2, E / 2], [D / 2, B, F / 2], [E / 2, F / 2, C]]), (m * g * R * (1 - Cos(th))))
        s2 = divide(Array([[i, 0, 0], [0, m, 0], [0, 0, m]]), (2 * m * g * R * (1 - Cos(th))))

        Eigvals1, Eigvecs1 = Eigh(s1)
        Eigvals2, Eigvecs2 = Eigh(s2)

        AA1 = Inv(Dot(Eigvecs1, Diag(Sqrt(Eigvals1))))
        AA2 = Inv(Dot(Eigvecs2, Diag(Sqrt(Eigvals2))))
        T1 = Array([R * Sin(th), 0, 1])
        T2 = Array([R * Cos(th), 1, 0])
        T11 = Dot(AA1, T1)
        T12 = Dot(AA1, T2)
        T21 = Dot(AA2, T1)
        T22 = Dot(AA2, T2)
        alpha1 = Acos(Dot(T11, T12) / Sqrt(Dot(T11, T11)) / Sqrt(Dot(T12, T12)))
        alpha2 = Acos(Dot(T21, T22) / Sqrt(Dot(T21, T21)) / Sqrt(Dot(T22, T22)))
        V1 = 4 * alpha1 * (m * g * R * (1 - Cos(th))) ** (3 / 2) / 3 / Sqrtm(
            4 * A * B * C + D * E * F - C * D ** 2 - B * E ** 2 - A * F ** 2)  # volume of the slice of the outer ellipsoid
        V2 = 4 * Sqrtm(2) * alpha2 * (m * g * R * (1 - Cos(th))) ** (3 / 2) / 3 / m / Sqrtm(
            i)  # volume of the slice of the inner ellipsoid

        if not Isnan(V1 - V2) and not Isinf(V1 - V2):  # in very edge cases, lack of python's precision could lead to errors
            return (V1 - V2) * interval
    except:
        pass


def evaluate(crth, ga, mu, R, rho, NORec):  # evaluates the probability of edge for the given conditions
    totalvol = 0
    vole = 0
    errors = 0
    for th in Linspace(crth / NORec, crth, num=NORec):
        try:
            vole += vol(th, crth / NORec, crth, ga, mu, R, rho)
        except:
            errors += 1

    for th in Linspace(-crth, -crth / NORec, num=NORec):
        try:
            vole += vol(th, crth / NORec, crth, ga, mu, R, rho)
        except:
            errors += 1

    for th in Linspace((crth - Pi / 2), (crth - Pi / 2) / NORec, num=NORec):
        try:
            totalvol += vol(th, (Pi / 2 - crth) / NORec, crth, ga, mu, R, rho)
        except:
            errors += 1

    for th in Linspace((Pi / 2 - crth) / NORec, (Pi / 2 - crth), num=NORec):
        try:
            totalvol += vol(th, (Pi / 2 - crth) / NORec, crth, ga, mu, R, rho)
        except:
            errors += 1

    totalvol += vole
    # if abs(vole/totalvol - 1 / 3) < 0.008:
    # print(crth, vole/totalvol)
    return vole / totalvol


def maxError(cB, NOV, NORec):  # determines the maximal error in percental deviation given conditionBounds and NOV
    maximalError = 0
    crthmax, gamax, mumax, Rmax, rhomax = 0, 0, 0, 0, 0
    NOBugs = 0
    for crth in Linspace(cB[0], cB[1], num=NOV):
        for ga in Linspace(cB[2], cB[3], num=NOV):
            for mu in Linspace(cB[4], cB[5], num=NOV):
                for R in Linspace(cB[6], cB[7], num=NOV):
                    for rho in Linspace(cB[8], cB[9], num=NOV):
                        currentVal = evaluate(crth, ga, mu, R, rho, NORec)
                        if abs(currentVal - paperModel(crth)) > maximalError:
                            crthmax, gamax, mumax, Rmax, rhomax = crth, ga, mu, R, rho
                            maximalError = currentVal
                        elif currentVal > 1:
                            NOBugs += 1
                            print(currentVal, crth, ga, mu, R, rho)
    return maximalError, [crthmax, gamax, mumax, Rmax, rhomax], "number of bugs: ", NOBugs



def variableError(cb, index, NOV, NORec):  # computes variance of a single variable only a variable changes we expect to not affect the result
    averageMse = 0
    for crth in Linspace(cb[0], cb[1], num=NOV):
        for ga in Linspace(cb[2], cb[3], num=NOV):
            for mu in Linspace(cb[4], cb[5], num=NOV):
                if index == 1:
                    for R in Linspace(cb[6], cb[7], num=NOV):
                        mse = 0
                        average = 0
                        arrayOfVals = []
                        for rho in Linspace(cb[8], cb[9], num=NOV):
                            currentVal = evaluate(crth, ga, mu, R, rho, NORec)
                            arrayOfVals.append(currentVal)
                            average += currentVal
                        for val in arrayOfVals:
                            mse += (average - val) ** 2
                        mse = sqrtm(mse / NOV)
                        averageMse += mse
                else:
                    for rho in Linspace(cb[8], cb[9], num=NOV):
                        mse = 0
                        average = 0
                        arrayOfVals = []
                        for R in Linspace(cb[6], cb[7], num=NOV):
                            currentVal = evaluate(crth, ga, mu, R, rho, NORec)
                            arrayOfVals.append(currentVal)
                            average += currentVal
                        for val in arrayOfVals:
                            mse += (average - val) ** 2
                        mse = sqrtm(mse / NOV)
                        averageMse += mse
    averageMse /= (NOV ** 4)
    return averageMse



def writeData(path, array):
    with open(path + ".txt", 'w') as output:  # writes the results into a .txt file to be read with mathematica
        for line in array:
            output.write(" ".join(str(x) for x in line) + "\n")


def threeDPlot(index1, index2, minval1, maxval1, minval2, maxval2, array, NOV, NORec):
    array.insert(index1, Linspace(minval1, maxval1, num=NOV))
    array.insert(index2, Linspace(minval2, maxval2, num=NOV))
    outputArray = []
    for val1 in array[0]:
        for val2 in array[1]:
            for val3 in array[2]:
                for val4 in array[3]:
                    for val5 in array[4]:
                        values = [val1, val2, val3, val4, val5]
                        outputArray.append([values[index1], values[index2], evaluate(val1, val2, val3, val4, val5, NORec)])
    return outputArray


def twoDPlot(index, minval, maxval, array, NOV, NORec):
    array.insert(index, Linspace(minval, maxval, num=NOV))
    outputArray = []
    for val1 in array[0]:
        for val2 in array[1]:
            for val3 in array[2]:
                for val4 in array[3]:
                    for val5 in array[4]:
                        values = [val1, val2, val3, val4, val5]
                        outputArray.append([values[index], evaluate(val1, val2, val3, val4, val5, NORec)])
    return outputArray


'''
    for crth in Linspace(0.125, Pi / 2 - 0.125, num=NOV):  # creates an array of points on the curve
        for rho in Linspace(100, 1000, num=NOV):
            result = evaluate(crth, ga, mu, R, rho, NORec)
            outputArray.append([crth, rho, result])
            outputArrayErrors.append([crth, rho, result - paperModel(crth)])
    return outputArray

def createLinspace(index, cb, NOV):
    return Linspace(cb[2 * index], cb[2 * index + 1], num=NOV)
'''


# print("Maximal Error: ", maxError(conditionBounds, NOV))
# print(evaluate(0.4427, 0.9, 0.7, 0.016, 2500))


def paperModel(crth):
    return (crth - Sin(crth)) / (Pi / 2 - Sin(crth) - Cos(crth))


'''
fig, ax = plt.subplots()

xArray1 = [0.3385, 0.47, 0.5256, 0.6987]
yArray1 = [0.134, 0.31, 0.373, 0.721]
yerr1 = [0.0366, 0.0438, 0.0392, 0.0493]
xArray2 = [0.3385, 0.47, 0.5256, 0.6987]
yArray2 = [0.164, 0.337, 0.424, 0.671]
yerr2 = [0.0395, 0.0447, 0.04, 0.0516]
xArray = []
yArray = []

plt.scatter(xArray, yArray)
ax.set_xlabel(r'$\theta_c$', fontsize=15)
ax.set_ylabel(r'$P_E$', fontsize=15)

x2 = arange(2.0)
y2 = 1/3 + x2 * 0
ax.plot(x2, y2)
plt.scatter(xArray1, yArray1, color="blue", label="Filled")
plt.errorbar(xArray1, yArray1, yerr=yerr1)
plt.scatter(xArray2, yArray2, color="orange", label="Hollow")
plt.errorbar(xArray2, yArray2, yerr=yerr2)
ax.hlines([1/3], 0, 1, transform=ax.get_yaxis_transform(), colors='r')
plt.legend()
plt.show()


t = arange(0.0, 2.0, 0.01)
s = 1 + Sin(2 * Pi * t)

fig, ax = plt.subplots()
ax.plot(t, s)

ax.set(xlabel='critical angle θc', ylabel='Probability of edge PE',
       title='Probability curve')
ax.grid()

fig.savefig("test.png")
plt.show()
'''
