import math

def findadress(nodes, searchingfor):
    left = 0
    right = len(nodes) - 1

    while left <= right:
        middle = (left + right) // 2
        if nodes[middle][:3] == searchingfor:
            return middle
        elif nodes[middle][:3] < searchingfor:
            left = middle + 1
        else:
            right = middle - 1

    return -1

def lastz(list):
    for i in range(len(list)):
        
        if (list[i][2] != "Z"):
            return False
    return True

def part1():
    f = open("input.in", "r")
    input = f.readlines()
    f.close()

    instructions = input[0]

    nodes = input[2:]
    nodes.sort()

    i = 0
    check = "AAA"

    while True:

        if check == "ZZZ":
            print (i)
            break

        var = i % (len(instructions)-1)

        inst = instructions[var]
        index = findadress(nodes,check)
        if(nodes[index][:3] != check):

            break


        if inst == 'L':
            check = nodes[index][7:][:3]
        elif inst == 'R':
            check = nodes[index][12:][:3]

        i += 1

    #binary search baby

def part2():
    f = open("input.in","r")
    input = f.readlines()
    f.close()

    instructions = input[0]
    looplengths = []

    nodes = input[2:]
    nodes.sort()
    startingnodes = []
    score = 0
    for i in range(len(nodes)):
        if nodes[i][2] == "A":
            startingnodes.append(nodes[i][:3])
        
    while True:

        inst = instructions[score % (len(instructions)-1)]

        for i in range(len(startingnodes)):
            node = startingnodes[i]
            
            index = findadress(nodes, node)
            

            if inst == 'L':
                startingnodes[i] = nodes[index][7:][:3]
            elif inst == 'R':
                startingnodes[i] = nodes[index][12:][:3]
        
        score += 1
        print(score)
        

part1()
part2()