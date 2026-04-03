$(document).ready(function () {

    function gatherCoAuthorData() {
        let coAuthors = [];
        $('#coAuthordata .co-author').each(function () {
            var coAuthor = {
                CoAuthorFullName: $(this).find('.CoAuthorFullName').val(),
                CoAuthorPosition: $(this).find('.CoAuthorPosition').val(),
                CoAuthorAffiliation: $(this).find('.CoAuthorAffiliation').val(),
                CoAuthorEmailId: $(this).find('.CoAuthorEmailId').val(),
                AuthorGuid: $(this).find('#txtAuthorGuid').val(),
            };
            if (coAuthor.CoAuthorFullName) {
                coAuthors.push(coAuthor);
            }
        });
        return coAuthors;
    }
    //remove
    $(document).on('click', '.Remove', function () {
        $(this).closest('.row').remove();
    });

    var coAuthorCount = 0;
    $('.AddAuthor').on('click', function () {
        coAuthorCount++;
        var newCoAuthor = $('.co-author:first').clone();
        newCoAuthor.find('input').val('');
        newCoAuthor.find('.Remove').removeClass('d-none');
        $('#coAuthordata').append(newCoAuthor);
    });
    $(document).on('click', '.remove-coauthor', function () {
        $(this).closest('.co-author').remove();
    });

    $('.btnsubmit').on('click', function (event) {
        event.preventDefault();

        if (
            $('.txtAuthFullName').val() === "" ||
            $('.txtAuthTitle').val() === "" ||
            $('.txtAuthAffiliation').val() === "" ||
            $('.txtAuthEmail').val() === "" ||
            $('.txtAuthPhone').val() === "" ||
            $('.txtConName').val() === "" ||
            $('.txtConEmail').val() === "" ||
            $('.txtConPhone').val() === "" ||
            $('.txtArticleTitle').val() === ""
        ) {
            $('.error-message').removeClass("d-none");
            $('.error-message').text('Please fill all the Required fields.');
        }
        else {
            var aGuid = $("[id*=txtAuthorGuid]").val();

            var Articles = {
                AuthorFullName: $('.txtAuthFullName').val(),
                AuthorGuid: aGuid,
                AuthorPosition: $('.txtAuthTitle').val(),
                AuthorAffiliation: $('.txtAuthAffiliation').val(),
                AuthorEmailId: $('.txtAuthEmail').val(),
                AuthorPhoneNo: $('.txtAuthPhone').val(),
                ArticleTitle: $('.txtArticleTitle').val(),
                ArticleAbstract: $('.txtAbstract').val(),
                ArticleKeywords: $('.txtKeywords').val(),
                ArticleType: $("[id*=ddlArticleType]").val(),
                ArticleWordCount: $('.txtWordCount').val(),
                ArticleTables: $('.txtFigures').val(),
                ArticleAnyOtherJournal: $('input[name$="RadioButtonList1"]:checked').val(),
                ArticlePublishedWork: $('input[name$="rabioBtnPublishedWorkCheck"]:checked').val(),
                ArticlePrevPublishedWork: $('.txtPublishWork').val(),
                ArticlePrevPublishedddl: $("[id*=ddlPrevPublishedWork]").val(),
                InterestToDeclare: $('input[name$="rabioBtnInterestAndFunding"]:checked').val(),
                DescInterestToDeclare: $('.DescInterestAndFunding').val() || "",
                Organization: $('input[name$="rabioBtnOrganization"]:checked').val(),
                DescOrganization: $('.DescOrganization').val() || "",
                Acknowledgments: $('.DescAcknowledgment').val() || "",
                EthicalCompliance: $('input[name$="rabioBtnReserach"]:checked').val(),
                DescEthicalCompliance: $('.DescEthicalCompliance').val() || "",
                Signature: $('.txtSignature').val(),
                Date: $('.txtDate').val(),
                AddedOn: $('.txtDate').val(),
                ContactInfoName: $('.txtConName').val(),
                ContactInfoEmailId: $('.txtConEmail').val(),
                ContactInfoPhoneNo: $('.txtConPhone').val(),
                AttachManuscript: $('.AttachManuscript').val() || "",
                AddedIp: "",
                Status: "Active",
                AttachSupplementoryManuscript: $('.AttachSupplementoryManuscript').val() || "",
                CoAuthors: gatherCoAuthorData()
            };
            $.ajax({
                type: "POST",
                url: "submit-an-article.aspx/SubmitArticle",
                data: JSON.stringify({ Articles: Articles }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.d == "Success") {
                        //Snackbar.show({ pos: 'top-right', text: 'Article  submitted successfully! .', actionTextColor: '#fff', backgroundColor: '#008a3d' });
                        window.location.href = "thank-you.aspx";
                        setTimeout(function () { window.location.href = "thank-you.aspx"; });
                        $('.txtAuthFullName').val('');
                        $('#authorGuid').val('');
                        $('.txtAuthTitle').val('');
                        $('.txtAuthAffiliation').val('');
                        $('.txtAuthEmail').val('');
                        $('.txtAuthPhone').val('');
                        $('.txtArticleTitle').val('');
                        $('.txtAbstract').val('');
                        $('.txtKeywords').val('');
                        $('.ddlArticleType').val('');
                        $('.txtWordCount').val('');
                        $('.txtFigures').val('');
                        $('input[name$="RadioButtonList1"]').prop('checked', false);
                        $('input[name$="rabioBtnPublishedWorkCheck"]').prop('checked', false);
                        $('.txtPublishWork').val('');
                        $('.ddlPrevPublishedWork').val('');
                        $('input[name$="rabioBtnInterestAndFunding"]').prop('checked', false);
                        $('.DescInterestAndFunding').val('');
                        $('input[name$="rabioBtnOrganization"]').prop('checked', false);
                        $('.DescOrganization').val('');
                        $('.DescAcknowledgment').val('');
                        $('input[name$="rabioBtnReserach"]').prop('checked', false);
                        $('.DescEthicalCompliance').val('');
                        $('.txtSignature').val('');
                        $('.txtDate').val('');
                        $('.txtConName').val('');
                        $('.txtConEmail').val('');
                        $('.txtConPhone').val('');
                        $('.AttachManuscript').val('');
                        $('.AttachSupplementoryManuscript').val('');
                    }
                    else {
                        Snackbar.show({ pos: 'top-right', text: 'Oops!!! There is some error right now, please try again after some time.', actionTextColor: '#fff', backgroundColor: '#ea1c1c' });

                    }
                },
            });
        }
        
    });




    $(document.body).on('change', '[id*=rabioBtnPublishedWorkCheck] input[type="radio"]', function () {
        var selectedValue = $(this).val();

        if (selectedValue === "Yes") {
            $('.divDescPublishedWork').removeClass("d-none");
            $('[id*=txtPublishWork]').val("");

        } else {
            $('.divDescPublishedWork').addClass("d-none");
            $('[id*=txtPublishWork]').val("");
        }
    });

    $(document.body).on('change', '[id*=rabioBtnInterestAndFunding] input[type="radio"]', function () {
        var selectedValue = $(this).val();

        if (selectedValue === "Yes") {
            $('.divInterestAndFunding').removeClass("d-none");
            $('[id*=DescInterestAndFunding]').val("");

        } else {
            $('.divInterestAndFunding').addClass("d-none");
            $('[id*=DescInterestAndFunding]').val("");
        }
    });

    $(document.body).on('change', '[id*=rabioBtnOrganization] input[type="radio"]', function () {
        var selectedValue = $(this).val();

        if (selectedValue === "Yes") {
            $('.divOrganization').removeClass("d-none");
            $('[id*=DescOrganization]').val("");

        } else {
            $('.divOrganization').addClass("d-none");
            $('[id*=DescOrganization]').val("");
        }
    });

    $(document.body).on('change', '[id*=rabioBtnReserach] input[type="radio"]', function () {
        var selectedValue = $(this).val();

        if (selectedValue === "Yes") {
            $('.divEthicalCompliance').removeClass("d-none");
            $('[id*=DescEthicalCompliance]').val("");

        } else {
            $('.divEthicalCompliance').addClass("d-none");
            $('[id*=DescEthicalCompliance]').val("");
        }
    });
});

const yesRadios = Array.from(document.getElementsByClassName('yesradio'));

// Get all radio buttons with the class 'noradio' and convert to an array
const noRadios = Array.from(document.getElementsByClassName('noradio'));

// Get all text area containers
const textAreas = Array.from(document.getElementsByClassName('textAreaContainer'));
// Function to hide all text areas
function hideAllTextAreas() {
    textAreas.forEach(textArea => {
        textArea.style.display = 'none';
    });
}
// Add event listeners to all 'yesradio' buttons
yesRadios.forEach(yesRadio => {
    yesRadio.addEventListener('change', function () {
        if (this.checked) {
            hideAllTextAreas(); // Hide all text areas
            const index = yesRadios.indexOf(this); // Find the index of the selected radio button
            if (index >= 0 && index < textAreas.length) {
                textAreas[index].style.display = 'block'; // Show the corresponding text area
            }
        }
    });
});

// Add event listeners to all 'noradio' buttons
noRadios.forEach(noRadio => {
    noRadio.addEventListener('change', function () {
        if (this.checked) {
            hideAllTextAreas(); // Hide all text areas
        }
    });

});

