import os
import sys
from pathlib import Path
from ScriptCollection.GeneralUtilities import GeneralUtilities
from ScriptCollection.ScriptCollectionCore import ScriptCollectionCore
from ScriptCollection.ProgramRunnerEpew import ProgramRunnerEpew
from ScriptCollection.TasksForCommonProjectStructure import TasksForCommonProjectStructure


@GeneralUtilities.check_arguments
def standardized_tasks_linting_for_node_project_in_common_project_structure(s: TasksForCommonProjectStructure, linting_script_file: str, verbosity: int,
                                                                            build_environment: str, commandline_arguments: list):
    sc = ScriptCollectionCore()
    sc.program_runner = ProgramRunnerEpew()
    build_script_folder = os.path.dirname(linting_script_file)
    codeunit_folder = GeneralUtilities.resolve_relative_path("../..", build_script_folder)
    sc.run_program("npm", "run lint", codeunit_folder)


def linting():
    standardized_tasks_linting_for_node_project_in_common_project_structure(TasksForCommonProjectStructure(), str(Path(__file__).absolute()), 1, "QualityCheck", sys.argv)


if __name__ == "__main__":
    linting()
