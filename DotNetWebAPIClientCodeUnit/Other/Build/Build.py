from ScriptCollection.GeneralUtilities import GeneralUtilities, Platform
from ScriptCollection.TFCPS.DotNet.TFCPS_CodeUnitSpecific_DotNet import TFCPS_CodeUnitSpecific_DotNet_Functions,TFCPS_CodeUnitSpecific_DotNet_CLI


def build():
    tf:TFCPS_CodeUnitSpecific_DotNet_Functions=TFCPS_CodeUnitSpecific_DotNet_CLI.parse(__file__)
    tf.build([GeneralUtilities.platform_to_dotnet_runtime_identifier(Platform.Windows_AMD64)], False)


if __name__ == "__main__":
    build()
