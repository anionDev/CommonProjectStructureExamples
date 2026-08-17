from ScriptCollection.TFCPS.Rust.TFCPS_CodeUnitSpecific_Rust import TFCPS_CodeUnitSpecific_Rust_Functions,TFCPS_CodeUnitSpecific_Rust_CLI


def linting():
    tf:TFCPS_CodeUnitSpecific_Rust_Functions=TFCPS_CodeUnitSpecific_Rust_CLI.parse(__file__)
    tf.linting()


if __name__ == "__main__":
    linting()
