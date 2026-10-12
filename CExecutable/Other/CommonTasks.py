from ScriptCollection.TFCPS.CPP.TFCPS_CodeUnitSpecific_CPP import TFCPS_CodeUnitSpecific_CPP_Functions, TFCPS_CodeUnitSpecific_CPP_CLI


def common_tasks():
    tf: TFCPS_CodeUnitSpecific_CPP_Functions = TFCPS_CodeUnitSpecific_CPP_CLI.parse(__file__)
    # do_common_tasks_base (called by do_common_tasks) also copies the build-artifact of CPPLibrary (declared in
    # CExecutable.codeunit.xml's dependentcodeunits) into Other/Resources/DependentCodeUnits/CPPLibrary, which is
    # what src/Makefile links against (see Build.py).
    tf.do_common_tasks(tf.get_version_of_project())  # codeunit-version should always be the same as project-version


if __name__ == "__main__":
    common_tasks()
