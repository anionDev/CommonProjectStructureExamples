import sys
from pathlib import Path
from ScriptCollection.TasksForCommonProjectStructure import TasksForCommonProjectStructure

def run_testcases_lint_for_maven_project(t:TasksForCommonProjectStructure,script_file:str,verbosity:int,commandline_arguments:list[str]):
    pass#TODO

def run_testcases():
    t = TasksForCommonProjectStructure()
    run_testcases_lint_for_maven_project(t,str(Path(__file__).absolute()), 1, sys.argv)


if __name__ == "__main__":
    run_testcases()
