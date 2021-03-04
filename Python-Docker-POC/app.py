import os, sys
print("Interpreter Version:" + sys.version)
print("Hello Docker!")
print("")
print("Execution Path:" + os.path.realpath(__file__))
print("Executing ls in current directory: ", os.listdir())

print("\n\nPOC Now running and waiting for your input..")

keyword = "not_exit"

while keyword!= "exit":
    keyword = input("")