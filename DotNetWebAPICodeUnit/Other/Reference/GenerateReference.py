from ScriptCollection.TFCPS.DotNet.TFCPS_CodeUnitSpecific_DotNet import TFCPS_CodeUnitSpecific_DotNet_Functions,TFCPS_CodeUnitSpecific_DotNet_CLI


def generate_reference():
    tf:TFCPS_CodeUnitSpecific_DotNet_Functions=TFCPS_CodeUnitSpecific_DotNet_CLI.parse(__file__)
    # Like the reference of a real service the reference of this codeunit consists of the articles and of the
    # api-specification, not of a class-reference: what a consumer of a webapi uses is its http-api and not its types.
    tf.generate_reference()


if __name__ == "__main__":
    generate_reference()
