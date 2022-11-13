import os
import sys
from pathlib import Path
from ScriptCollection.GeneralUtilities import GeneralUtilities
from ScriptCollection.ScriptCollectionCore import ScriptCollectionCore
from ScriptCollection.ProgramRunnerEpew import ProgramRunnerEpew
from ScriptCollection.TasksForCommonProjectStructure import TasksForCommonProjectStructure


@GeneralUtilities.check_arguments
def standardized_tasks_run_testcases_for_node_project_in_common_project_structure(s: TasksForCommonProjectStructure, build_script_file: str,
                                                                                  buildenvironment: str, generate_badges: bool, verbosity: int,
                                                                                  commandline_arguments: list):
    sc = ScriptCollectionCore()
    sc.program_runner = ProgramRunnerEpew()
    build_script_folder = os.path.dirname(build_script_file)
    codeunit_folder = GeneralUtilities.resolve_relative_path("../..", build_script_folder)
    sc.run_program("npm", "run test", codeunit_folder)
    coverage_folder = os.path.join(codeunit_folder, "Other", "Artifacts", "TestCoverage")
    target_file = os.path.join(coverage_folder, "TestCoverage.xml")
    GeneralUtilities.ensure_file_does_not_exist(target_file)
    os.rename(os.path.join(coverage_folder, "cobertura-coverage.xml"), target_file)
    repository_folder = GeneralUtilities.resolve_relative_path("..", codeunit_folder)
    codeunitname = os.path.basename(codeunit_folder)
    s.check_testcoverage_for_project_in_common_project_structure(target_file, repository_folder, codeunitname)
    s.standardized_tasks_generate_coverage_report(repository_folder, codeunitname, verbosity, generate_badges, buildenvironment, commandline_arguments)
    s.update_path_of_source(repository_folder, codeunitname)


def run_testcases():
    standardized_tasks_run_testcases_for_node_project_in_common_project_structure(
        TasksForCommonProjectStructure(), str(Path(__file__).absolute()), "QualityCheck", True, 1, sys.argv)


if __name__ == "__main__":
    run_testcases()
