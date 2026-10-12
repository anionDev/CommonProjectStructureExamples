from ScriptCollection.TFCPS.DotNet.TFCPS_CodeUnitSpecific_DotNet import TFCPS_CodeUnitSpecific_DotNet_Functions,TFCPS_CodeUnitSpecific_DotNet_CLI


def build():
    tf:TFCPS_CodeUnitSpecific_DotNet_Functions=TFCPS_CodeUnitSpecific_DotNet_CLI.parse(__file__)
    # The second argument makes the build generate the api-specification of this codeunit. The codeunits which
    # use this api (DotNetWebAPIClientCodeUnit and AngularCodeUnit) generate their client out of that artifact.
    tf.build(True)


if __name__ == "__main__":
    build()
