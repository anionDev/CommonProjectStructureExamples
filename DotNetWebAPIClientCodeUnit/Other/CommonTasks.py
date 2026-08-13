from ScriptCollection.TFCPS.DotNet.TFCPS_CodeUnitSpecific_DotNet import TFCPS_CodeUnitSpecific_DotNet_Functions,TFCPS_CodeUnitSpecific_DotNet_CLI
from ScriptCollection.TFCPS.DotNet.CertificateGeneratorInformationNoGenerate import CertificateGeneratorInformationNoGenerate


def common_tasks():
    tf:TFCPS_CodeUnitSpecific_DotNet_Functions=TFCPS_CodeUnitSpecific_DotNet_CLI.parse(__file__)
    tf.do_common_tasks(tf.get_version_of_project(),CertificateGeneratorInformationNoGenerate())#codeunit-version should always be the same as project-version
    # The testcases need to know where this codeunit is located to be able to start the server of the dependent
    # codeunit. That constant is generated from a template here; without this call it keeps the value of the
    # machine on which it was generated the last time.
    tf.tfcps_Tools_General.t4_transform(tf.get_codeunit_folder(),True,tf.use_cache())


if __name__ == "__main__":
    common_tasks()
