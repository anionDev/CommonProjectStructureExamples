from ScriptCollection.TFCPS.CPP.TFCPS_CodeUnitSpecific_CPP import TFCPS_CodeUnitSpecific_CPP_Functions, TFCPS_CodeUnitSpecific_CPP_CLI


def generate_reference():
    tf: TFCPS_CodeUnitSpecific_CPP_Functions = TFCPS_CodeUnitSpecific_CPP_CLI.parse(__file__)
    # docfx can not extract a class-reference from c++-sourcecode, so only the articles of the reference-content are generated.
    tf.generate_reference()


if __name__ == "__main__":
    generate_reference()
