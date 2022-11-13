import sys
import os
from pathlib import Path
from ScriptCollection.ScriptCollectionCore import ScriptCollectionCore
from ScriptCollection.GeneralUtilities import GeneralUtilities
from ScriptCollection.ProgramRunnerEpew import ProgramRunnerEpew
from ScriptCollection.TasksForCommonProjectStructure import TasksForCommonProjectStructure
import json


def replace_version_in_package_file(self: ScriptCollectionCore, package_json_file: str, version: str):
    filename = package_json_file
    with open(filename, 'r', encoding="utf-8") as f:
        data = json.load(f)
        data['version'] = version
    os.remove(filename)
    with open(filename, 'w', encoding="utf-8") as f:
        json.dump(data, f, indent=2)


def common_tasks():
    file = str(Path(__file__).absolute())
    folder_of_current_file = os.path.dirname(file)
    codeunit_folder = GeneralUtilities.resolve_relative_path("..", folder_of_current_file)
    sc = ScriptCollectionCore()
    version = sc.get_semver_version_from_gitversion(GeneralUtilities.resolve_relative_path("../..", os.path.dirname(file)))
    sc.program_runner = ProgramRunnerEpew()
    sc.run_program("npm", "install", codeunit_folder)
    TasksForCommonProjectStructure().update_version_of_codeunit_to_project_version(file, version)
    replace_version_in_package_file(sc, GeneralUtilities.resolve_relative_path("../package.json", folder_of_current_file), version)


if __name__ == "__main__":
    common_tasks()
