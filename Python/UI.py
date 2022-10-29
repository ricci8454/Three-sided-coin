from New_Model import *

defaultPath = "C://Users//ricci//Desktop//SYPT//SYPT 2022//Data//Numerical Model Data"

def take_input(name, array):
    try:
        x, y = [float(s) for s in input("Enter minimal and maximal for the " + name + ": ").split()]
    except:
        return True
    array.append(x)
    array.append(y)
    return x > y

def inputCB():
    conditionbounds = []
    is_valid_input = False
    while (not is_valid_input):
        is_valid_input = True
        for name in ["arctan(h/d)", "coefficient of restitution", "friction coefficient", "radius", "density"]:
            if take_input(name, conditionbounds):
                print("Input no good")
                is_valid_input = False
                break
    return conditionbounds

while True:
    mode = int(input("For 2DPlot type 1, for 3DPlot type 2, for variance of mass/density 3: "))
    if mode == 0:
        writeData(defaultPath + "//testdensity", twoDPlot(3, 100, 5000, [[0.8], [0.5], [0.5], [0.0125]], 50, 100))
        break
    elif mode == 1:
        index = int(input("Variable to be plotted: 0 - critical angle [rad], 1 - COR, 2 - COF, 3 - radius [m], 4 - density [kg /m^3]: "))
        minval, maxval = [float(s) for s in input("Minimal and maximal value of the index: ").split()]
        array = [[float(s)] for s in input("Remaining values in correct order: ").split()]
        NOV = int(input("Number of values to be plotted: "))
        NORec = int(input("Number of rectangles in Riemann Sum: "))
        fileName = input("Enter File Name: ")
        writeData(defaultPath + "//" + fileName, twoDPlot(index, minval, maxval, array, NOV, NORec))
        print("File saved at: " + defaultPath)
        break
    elif mode == 2:
        index1, index2 = [int(s) for s in input("Two variables to be plotted (increasing): 0 - critical angle [rad], 1 - COR, 2 - COF, 3 - radius [m], 4 - density [kg /m^3]: ").split()]
        minval1, maxval1 = [float(s) for s in input("Minimal and maximal value of the first variable: ").split()]
        minval2, maxval2 = [float(s) for s in input("Minimal and maximal value of the second variable: ").split()]
        array = [[float(s)] for s in input("Remaining values in correct order: ").split()]
        NOV = int(input("Number of values to be plotted: "))
        NORec = int(input("Number of rectangles in Riemann Sum: "))
        fileName = input("Enter File Name: ")
        writeData(defaultPath + "//" + fileName,
                                threeDPlot(index1, index2, minval1, maxval1, minval2, maxval2, array, NOV, NORec))
        print("File saved as: " + defaultPath)
        break
    elif mode == 3:
        while True:
            index = int(input("0 for radius, 1 for density: "))
            if index == 1 or index == 0:
                break
            print("0 or 1, it's not that complicated.")
        print("Variance of " + variableError(inputCB(), index, int(input("Number of values: ")), int(input("Number of rectangles: "))))
    else:
        print("Enter valid number")
