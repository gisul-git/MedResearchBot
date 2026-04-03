    function toggleModuleFields() {
    var moduleType = document.getElementById('<%= ddlModuleType.ClientID %>').value;
    var textContentField = document.getElementById('textContentField');
    var videoLinkField = document.getElementById('videoLinkField');
    var textContentValidator = document.getElementById('<%= rfvTextContent.ClientID %>');
    var videoLinkValidator = document.getElementById('<%= rfvVideoLink.ClientID %>');

    // Hide all fields first
    if (textContentField) textContentField.style.display = 'none';
    if (videoLinkField) videoLinkField.style.display = 'none';

    // Disable validators first
    if (textContentValidator) textContentValidator.enabled = false;
    if (videoLinkValidator) videoLinkValidator.enabled = false;

    // Show relevant field based on module type
    if (moduleType === 'Text Content') {
            if (textContentField) textContentField.style.display = 'block';
    if (textContentValidator) textContentValidator.enabled = true;
        } else if (moduleType === 'YouTube Video' || moduleType === 'Our Video') {
            if (videoLinkField) videoLinkField.style.display = 'block';
    if (videoLinkValidator) videoLinkValidator.enabled = true;
        }
    }

    // Initialize on page load
    document.addEventListener('DOMContentLoaded', function () {
        toggleModuleFields();

    // Add event listener for module type change
    var moduleTypeDropdown = document.getElementById('<%= ddlModuleType.ClientID %>');
    if (moduleTypeDropdown) {
        moduleTypeDropdown.addEventListener('change', toggleModuleFields);
        }
    });

    // Also call when ASP.NET postback completes (for UpdatePanel support)
    var prm = Sys.WebForms.PageRequestManager.getInstance();
    prm.add_endRequest(function () {
        toggleModuleFields();

    // Re-attach event listener after postback
    var moduleTypeDropdown = document.getElementById('<%= ddlModuleType.ClientID %>');
    if (moduleTypeDropdown) {
        moduleTypeDropdown.addEventListener('change', toggleModuleFields);
        }
    });

