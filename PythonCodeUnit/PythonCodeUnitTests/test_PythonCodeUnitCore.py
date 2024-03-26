import unittest
from ..PythonCodeUnit.PythonCodeUnitCore import PythonCodeUnitCore


class PythonCodeUnitCoreTests(unittest.TestCase):

    def test_executable_1(self):
        # arrange
        pcuc = PythonCodeUnitCore()
        parameter1 = "str1"
        parameter2 = "str2"
        expected_result = "str1str2"

        # act
        actual_result = pcuc.executable_1(parameter1,   parameter2)

        # assert
        assert expected_result == actual_result

    def test_executable_2(self):
        # arrange
        pcuc = PythonCodeUnitCore()
        parameter1 = "str1"
        parameter2 = "str2"
        expected_result = "str2str1"

        # act
        actual_result = pcuc.executable_2(parameter1,   parameter2)

        # assert
        assert expected_result == actual_result
