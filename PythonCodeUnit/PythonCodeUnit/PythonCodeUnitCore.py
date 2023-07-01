from ScriptCollection.GeneralUtilities import GeneralUtilities

version = "3.4.1"
__version__ = version


class PythonCodeUnitCore:

    @GeneralUtilities.check_arguments
    def executable_1(self, parameter1: str, parameter2: str) -> str:
        return parameter1+parameter2

    @GeneralUtilities.check_arguments
    def executable_2(self, parameter1: str, parameter2: str) -> str:
        return parameter1+parameter2
