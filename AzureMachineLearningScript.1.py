# The script MUST contain a function named azureml_main
# which is the entry point for this module.

# imports up here can be used to
import pandas as pd
import numpy as np

# The entry point function can contain up to two input arguments:
def azureml_main(stock_data = None):

    stock_data_length = len(stock_data)

    prices = np.array(stock_data[stock_data.columns[0]]) # Š”‰¿ƒf[ƒ^

    # Š”‰¿‚Ìã¸—¦‚ğZo
    modified_data = []

    for i in range(1, stock_data_length):
        modified_data.append(float(prices[i] - prices[i - 1]) / float(prices[i - 1]))
    modified_data_length = len(modified_data)

    # ‘O“ú‚Ü‚Å‚Ì2TŠÔ•ª‚Ìã¸—¦‚Ìƒf[ƒ^
    sequential_data = []
    # ³‰ğ’l ‰¿Šiã¸: 1 ‰¿Ši’á‰º: 0
    answers = []
    day_range = 7 * 2 # 2TŠÔ

    for day in range(day_range):
        sequential_data.append([])
        for i in range(day_range, modified_data_length):
            sequential_data[day].append(modified_data[i - day_range + day])

    for i in range(day_range, modified_data_length):
        answers.append(1 if modified_data[i] > 0 else 0)

    result = pd.DataFrame()
    for i in range(day_range):
        result["Rate" + str(i)] = sequential_data[0]
    result["Answer"] = answers
    return result
