from ScriptCollection.GeneralUtilities import Platform
from ScriptCollection.TFCPS.Docker.TFCPS_CodeUnitSpecific_Docker import TFCPS_CodeUnitSpecific_Docker_Functions,TFCPS_CodeUnitSpecific_Docker_CLI


def build():
    platforms:list[Platform] = [
            Platform.Linux_AMD64,
            Platform.Linux_ARM64,
    ]
    tf:TFCPS_CodeUnitSpecific_Docker_Functions=TFCPS_CodeUnitSpecific_Docker_CLI.parse(__file__)
    tf.build(platforms,{})
    # The BOM of SpringAPI is not merged into the BOM of this codeunit (unlike WebAPIContainerCodeUnit does it with the one of
    # DotNetWebAPICodeUnit), because merge_sbom_file_from_dependent_codeunit_into_this expects "<codeunit>.<version>.sbom.xml"
    # while the maven-build of ScriptCollection stores it as "<codeunit>.<version>.bom.xml".


if __name__ == "__main__":
    build()
