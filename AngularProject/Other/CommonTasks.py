import sys
import os
from pathlib import Path
from ScriptCollection.ScriptCollectionCore import ScriptCollectionCore
from ScriptCollection.GeneralUtilities import GeneralUtilities
from ScriptCollection.TasksForCommonProjectStructure import TasksForCommonProjectStructure


def common_tasks():
    file = str(Path(__file__).absolute())
    folder_of_current_file = os.path.dirname(file)
    codeunit_folder = GeneralUtilities.resolve_relative_path("..", folder_of_current_file)
    sc = ScriptCollectionCore()
    version = sc.get_semver_version_from_gitversion(GeneralUtilities.resolve_relative_path("../..", os.path.dirname(file)))
    t = TasksForCommonProjectStructure()
    t.update_version_of_codeunit_to_project_version(file, version)
    t.replace_version_in_package_file(GeneralUtilities.resolve_relative_path("../package.json", folder_of_current_file), version)
    t.do_npm_install(codeunit_folder)


if __name__ == "__main__":
    common_tasks()
