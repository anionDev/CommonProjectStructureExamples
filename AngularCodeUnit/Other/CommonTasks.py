import os
import shutil
from ScriptCollection.TFCPS.NodeJS.TFCPS_CodeUnitSpecific_NodeJS import TFCPS_CodeUnitSpecific_NodeJS_Functions,TFCPS_CodeUnitSpecific_NodeJS_CLI

def common_tasks():
    tf:TFCPS_CodeUnitSpecific_NodeJS_Functions=TFCPS_CodeUnitSpecific_NodeJS_CLI.parse(__file__)
    tf.do_common_tasks(tf.get_version_of_project())#codeunit-version should always be the same as project-version
    codeunit_folder = tf.get_codeunit_folder()
    tf.tfcps_Tools_General.generate_api_client_from_dependent_codeunit(tf.get_codeunit_folder(),"DotNetWebAPICodeUnit","src/app/generated/dot-net-web-api-code-unit","typescript-angular",tf.use_cache(),["apis","models","supportingFiles"])
    tf.organize_translations([
        "ar",  # Arabic
        "de",  # German
        "de-AT",  # German (Austria)
        "de-CH",  # German (Switzerland)
        "el",  # Greek
        "en",  # English
        "en-GB",  # English (United Kingdom)
        "es",  # Spanish
        "es-MX",  # Spanish (Mexico)
        "fr",  # French
    ])

if __name__ == "__main__":
    common_tasks()
 