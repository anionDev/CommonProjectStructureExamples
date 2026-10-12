from ScriptCollection.TFCPS.Rust.TFCPS_CodeUnitSpecific_Rust import TFCPS_CodeUnitSpecific_Rust_Functions,TFCPS_CodeUnitSpecific_Rust_CLI


def generate_reference():
    tf:TFCPS_CodeUnitSpecific_Rust_Functions=TFCPS_CodeUnitSpecific_Rust_CLI.parse(__file__)
    # docfx can not extract a class-reference from rust-sourcecode, so only the articles of the reference-content are generated.
    tf.generate_reference()


if __name__ == "__main__":
    generate_reference()
