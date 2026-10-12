from ScriptCollection.TFCPS.Go.TFCPS_CodeUnitSpecific_Go import TFCPS_CodeUnitSpecific_Go_Functions,TFCPS_CodeUnitSpecific_Go_CLI


def generate_reference():
    tf:TFCPS_CodeUnitSpecific_Go_Functions=TFCPS_CodeUnitSpecific_Go_CLI.parse(__file__)
    # docfx can not extract a class-reference from go-sourcecode, so only the articles of the reference-content are generated.
    tf.generate_reference()


if __name__ == "__main__":
    generate_reference()
