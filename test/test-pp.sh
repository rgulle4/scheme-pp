#!/bin/bash
set -e

# -- Set up ------------------------------------- #

DIFF_TOOL='meld'
INPUT_FILE='test1.scm'

OUTPUT_FILE_REFERENCE='test/output-reference.txt'
OUTPUT_FILE_OURS='test/output-ours.txt'

BINARY_REFERENCE='SPP-reference.exe'
BINARY_OURS='SPP.exe'


# cli for input file
if [ $# == 1 ]; then
  INPUT_FILE="${1%/}"
fi

# -- Main --------------------------------------- #

echo "-- Make ---------------------------"
make

echo
echo "-- Running reference binary... ----"
cat $INPUT_FILE | mono $BINARY_REFERENCE > $OUTPUT_FILE_REFERENCE

echo
echo "-- Running our binary... ----------"
cat $INPUT_FILE | mono $BINARY_OURS > $OUTPUT_FILE_OURS

echo
echo "-- Diffing results... -------------"
$DIFF_TOOL $OUTPUT_FILE_REFERENCE $OUTPUT_FILE_OURS
