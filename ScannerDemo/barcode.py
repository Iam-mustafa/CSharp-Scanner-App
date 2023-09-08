from inspect import getinnerframes
from pyzbar import pyzbar
import cv2
import math
import sys

def getImageBarcode(path):
    image = cv2.imread(path)
    height = image.shape[0]
    percent = math.ceil(height*25/100)
    crop =  image[:percent, :]
    barcode = pyzbar.decode(crop)
    BARCODES = []
    for bar in barcode:
        barcodeData = bar.data.decode("utf-8")
        BARCODES.append(barcodeData)
    print(BARCODES)

if __name__ == '__main__':
    getImageBarcode(sys.argv[1])