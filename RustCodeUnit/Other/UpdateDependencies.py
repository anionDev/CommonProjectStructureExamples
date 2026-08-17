from ScriptCollection.TFCPS.Rust.TFCPS_CodeUnitSpecific_Rust import TFCPS_CodeUnitSpecific_Rust_Functions,TFCPS_CodeUnitSpecific_Rust_CLI


def update_dependencies():
    tf:TFCPS_CodeUnitSpecific_Rust_Functions=TFCPS_CodeUnitSpecific_Rust_CLI.parse(__file__)
    tf.update_dependencies()


if __name__ == "__main__":
    update_dependencies()
