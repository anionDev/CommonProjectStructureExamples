from ScriptCollection.TFCPS.Maven.TFCPS_CodeUnitSpecific_Maven import TFCPS_CodeUnitSpecific_Maven_Functions,TFCPS_CodeUnitSpecific_Maven_CLI


def common_tasks():
    tf:TFCPS_CodeUnitSpecific_Maven_Functions=TFCPS_CodeUnitSpecific_Maven_CLI.parse(__file__)
    tf.do_common_tasks(tf.get_version_of_project())#codeunit-version should always be the same as project-version


if __name__ == "__main__":
    common_tasks()
