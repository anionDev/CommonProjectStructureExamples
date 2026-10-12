from ScriptCollection.TFCPS.Rust.TFCPS_CodeUnitSpecific_Rust import TFCPS_CodeUnitSpecific_Rust_Functions,TFCPS_CodeUnitSpecific_Rust_CLI


def common_tasks():
    tf:TFCPS_CodeUnitSpecific_Rust_Functions=TFCPS_CodeUnitSpecific_Rust_CLI.parse(__file__)
    tf.do_common_tasks(tf.get_version_of_project())#codeunit-version should always be the same as project-version


if __name__ == "__main__":
    common_tasks()
