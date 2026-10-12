from ScriptCollection.TFCPS.Maven.TFCPS_CodeUnitSpecific_Maven import TFCPS_CodeUnitSpecific_Maven_Functions,TFCPS_CodeUnitSpecific_Maven_CLI


def generate_reference():
    tf:TFCPS_CodeUnitSpecific_Maven_Functions=TFCPS_CodeUnitSpecific_Maven_CLI.parse(__file__)
    # docfx can not extract a class-reference from java-sourcecode, so only the articles of the reference-content are generated.
    tf.generate_reference()


if __name__ == "__main__":
    generate_reference()
