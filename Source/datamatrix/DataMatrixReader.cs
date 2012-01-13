/*
 * Copyright 2007 ZXing authors
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System.Collections.Generic;

using com.google.zxing.common;
using com.google.zxing.datamatrix.decoder;
using com.google.zxing.datamatrix.detector;

namespace com.google.zxing.datamatrix
{
   /// <summary>
   /// This implementation can detect and decode Data Matrix codes in an image.
   ///
   /// <author>bbrown@google.com (Brian Brown)</author>
   /// </summary>
   public sealed class DataMatrixReader : Reader
   {
      private static ResultPoint[] NO_POINTS = new ResultPoint[0];

      private Decoder decoder = new Decoder();

      /// <summary>
      /// Locates and decodes a Data Matrix code in an image.
      ///
      /// <returns>a String representing the content encoded by the Data Matrix code</returns>
      /// <exception cref="NotFoundException">if a Data Matrix code cannot be found</exception>
      /// <exception cref="FormatException">if a Data Matrix code cannot be decoded</exception>
      /// <exception cref="ChecksumException">if error correction fails</exception>
      /// </summary>
      public Result decode(BinaryBitmap image)
      {
         return decode(image, null);
      }

      public Result decode(BinaryBitmap image, IDictionary<DecodeHintType, object> hints)
      {
         DecoderResult decoderResult;
         ResultPoint[] points;
         if (hints != null && hints.ContainsKey(DecodeHintType.PURE_BARCODE))
         {
            BitMatrix bits = extractPureBits(image.BlackMatrix);
            decoderResult = decoder.decode(bits);
            points = NO_POINTS;
         }
         else
         {
            DetectorResult detectorResult = new Detector(image.BlackMatrix).detect();
            decoderResult = decoder.decode(detectorResult.Bits);
            points = detectorResult.Points;
         }
         Result result = new Result(decoderResult.Text, decoderResult.RawBytes, points,
             BarcodeFormat.DATA_MATRIX);
         IList<sbyte[]> byteSegments = decoderResult.ByteSegments;
         if (byteSegments != null)
         {
            result.putMetadata(ResultMetadataType.BYTE_SEGMENTS, byteSegments);
         }
         var ecLevel = decoderResult.ECLevel;
         if (ecLevel != null)
         {
            result.putMetadata(ResultMetadataType.ERROR_CORRECTION_LEVEL, ecLevel);
         }
         return result;
      }

      public void reset()
      {
         // do nothing
      }

      /// <summary>
      /// This method detects a code in a "pure" image -- that is, pure monochrome image
      /// which contains only an unrotated, unskewed, image of a code, with some white border
      /// around it. This is a specialized method that works exceptionally fast in this special
      /// case.
      ///
      /// @see com.google.zxing.pdf417.PDF417Reader#extractPureBits(BitMatrix)
      /// @see com.google.zxing.qrcode.QRCodeReader#extractPureBits(BitMatrix)
      /// </summary>
      private static BitMatrix extractPureBits(BitMatrix image)
      {

         int[] leftTopBlack = image.getTopLeftOnBit();
         int[] rightBottomBlack = image.getBottomRightOnBit();
         if (leftTopBlack == null || rightBottomBlack == null)
         {
            throw NotFoundException.Instance;
         }

         int moduleSize = DataMatrixReader.moduleSize(leftTopBlack, image);

         int top = leftTopBlack[1];
         int bottom = rightBottomBlack[1];
         int left = leftTopBlack[0];
         int right = rightBottomBlack[0];

         int matrixWidth = (right - left + 1) / moduleSize;
         int matrixHeight = (bottom - top + 1) / moduleSize;
         if (matrixWidth <= 0 || matrixHeight <= 0)
         {
            throw NotFoundException.Instance;
         }

         // Push in the "border" by half the module width so that we start
         // sampling in the middle of the module. Just in case the image is a
         // little off, this will help recover.
         int nudge = moduleSize >> 1;
         top += nudge;
         left += nudge;

         // Now just read off the bits
         BitMatrix bits = new BitMatrix(matrixWidth, matrixHeight);
         for (int y = 0; y < matrixHeight; y++)
         {
            int iOffset = top + y * moduleSize;
            for (int x = 0; x < matrixWidth; x++)
            {
               if (image[left + x * moduleSize, iOffset])
               {
                  bits[x, y] = true;
               }
            }
         }
         return bits;
      }

      private static int moduleSize(int[] leftTopBlack, BitMatrix image)
      {
         int width = image.Width;
         int x = leftTopBlack[0];
         int y = leftTopBlack[1];
         while (x < width && image[x, y])
         {
            x++;
         }
         if (x == width)
         {
            throw NotFoundException.Instance;
         }

         int moduleSize = x - leftTopBlack[0];
         if (moduleSize == 0)
         {
            throw NotFoundException.Instance;
         }
         return moduleSize;
      }

   }
}
