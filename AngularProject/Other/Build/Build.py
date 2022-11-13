import os
import sys
from pathlib import Path
from ScriptCollection.GeneralUtilities import GeneralUtilities
from ScriptCollection.ScriptCollectionCore import ScriptCollectionCore
from ScriptCollection.ProgramRunnerEpew import ProgramRunnerEpew
from ScriptCollection.TasksForCommonProjectStructure import TasksForCommonProjectStructure


def standardized_tasks_build_for_node_library_project_in_common_project_structure(self: TasksForCommonProjectStructure, build_script_file: str,
                                                                                  build_configuration: str, verbosity: int, commandline_arguments: list):
    sc = ScriptCollectionCore()
    sc.program_runner = ProgramRunnerEpew()
    build_script_folder = os.path.dirname(build_script_file)
    codeunit_folder = GeneralUtilities.resolve_relative_path("../..", build_script_folder)
    sc.run_program("npm", "run build", codeunit_folder)


def build():
    standardized_tasks_build_for_node_library_project_in_common_project_structure(TasksForCommonProjectStructure(),
                                                                                  str(Path(__file__).absolute()), "QualityCheck",  1, sys.argv)


if __name__ == "__main__":
    build()
