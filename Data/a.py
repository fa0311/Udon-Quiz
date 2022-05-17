
import regex



list = ["","","","","","",""]
for i in range(20):
    with open(str(i + 1) + ".csv", encoding="utf-8") as f:
        s = f.read()

    file = ""
    for column in s.split("\n"):
        anser = column.split(",")[-1]
        if(len(column.split(",")) != 2):
            print(column)
            continue
        last = ""

        anser = regex.sub('[『』  ／「」]', '', anser)
        anser = regex.sub('\\(.*?\\)', '', anser)
        anser = regex.sub('\\（.*?\\）', '', anser)
        anser = regex.sub('㎜', 'mm', anser)

        if(anser == ""):
            print(column)

        for char in anser:
            if(regex.search(r'[0-9]', char)):
                last += "0"
                if char not in list[0]:
                    list[0] += char
            elif(regex.search(r'[a-z]', char)):
                last += "1"
                if char not in list[1]:
                    list[1] += char
            elif(regex.search(r'[A-Z]', char)):
                last += "2"
                if char not in list[2]:
                    list[2] += char
            elif(regex.search('[\u3041-\u309F]', char)):
                last += "3"
                if char not in list[3]:
                    list[3] += char
            elif(regex.search('[\u30A1-\u30FF]', char)):
                last += "4"
                if char not in list[4]:
                    list[4] += char
            elif(regex.search('[\uFF01-\uFF0F\uFF1A-\uFF20\uFF3B-\uFF40\uFF5B-\uFF65\u3000-\u303F\u0020-\u002F\u003A-\u0040\u005B-\u0060\u007B-\u007E×☆πΣ♂]', char)):
                last += "5"
                print(column)
                if char not in list[5]:
                    list[5] += char
            elif(regex.search(r'\p{Script=Han}', char)):
                last += "6"
                if char not in list[6]:
                    list[6] += char
            else:
                print(char)
                print(anser)
        file += column.split(",")[0] + "," + anser + "," + last + "\n"

        with open("" + str(i + 1) + ".csv", mode='w', encoding="utf-8") as f:
            f.write(file[:-1])

file = ""
for text in list:
    file += text + "\n"

with open("choices.csv", mode='w', encoding="utf-8") as f:
    f.write(file[:-1])

