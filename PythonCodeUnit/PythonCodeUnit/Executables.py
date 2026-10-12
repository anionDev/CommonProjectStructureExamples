import argparse
from ScriptCollection.GeneralUtilities import GeneralUtilities
from .PythonCodeUnitCore import PythonCodeUnitCore


def executable_1() -> int:
    parser = argparse.ArgumentParser(description='Some example function.')
    parser.add_argument("parameter1")
    parser.add_argument("parameter2")
    args = parser.parse_args()
    GeneralUtilities.write_message_to_stdout(PythonCodeUnitCore().executable_1(args.parameter1, args.parameter2))
    return 0


def executable_2() -> int:
    parser = argparse.ArgumentParser(description='Some example function.')
    parser.add_argument("parameter1")
    parser.add_argument("parameter2")
    args = parser.parse_args()
    GeneralUtilities.write_message_to_stdout(PythonCodeUnitCore().executable_2(args.parameter1, args.parameter2))
    return 0
