<%@ Page Title="" Language="C#" MasterPageFile="./MasterPage.master" AutoEventWireup="true" CodeFile="forum-details.aspx.cs" Inherits="fourm_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="/js/snackbar/snackbar.min.css" rel="stylesheet" />
    <style>
        header.nav-homepage-style {
            background: #000;
            position: relative;
        }
           ul.cats .badge{
       height:26px;
       margin-left:20px;
   }
           ul.cats li{
               padding-right:100px;
           }
        .breadcumb-section {
            padding: 0px 0px;
        }

        .logos.me-4 {
            position: absolute;
        }



        .new-li {
            display: flex;
            gap: 1rem;
            padding-left: 0px;
            justify-content: start;
        }

        .new0bg {
            background-color: #ff7f3e;
        }

        .nav-link {
            padding: 10px 0px;
            font-size: 18px;
        }

        .list-style1 li {
            display: block !important;
        }

        .list-style1 i {
            margin-top: 6px;
        }

        .list-inline-item {
            display: flex;
            align-items: center;
        }


        .blocktxt {
            font-size: 14px;
            color: #363838;
        }

        ul.cats {
            margin: 0;
            padding: 0;
        }

            ul.cats li {
                list-style: none;
                display: block;
                margin: 0;
                padding: 0;
                line-height: 30px;
                margin-bottom: 10px;
            }

                ul.cats li a {
                    font-size: 16px;
                    color: #363838;
                    line-height: 28px;
                    display: flex;
                    justify-content: space-between;
                }

            ul.cats .badge {
                background-color: #ff7f3e;
                font-size: 12px;
                color: #ffffff;
                padding: 5px 10px;
                line-height: 16px;
            }

        .post .comments {
            border-bottom: solid 1px #f1f1f1;
            padding: 15px 0 15px 0;
            text-align: center;
        }

            .post .comments .commentbg {
                background-color: #bdc3c7;
                border-radius: 2px;
                display: inline-block;
                padding: 8px 15px;
                color: #ffffff;
                font-size: 14px;
                font-family: 'Open Sans Bold', sans-serif;
                position: relative;
            }

                .post .comments .commentbg .mark {
                    width: 11px;
                    height: 11px;
                    background-color: #bdc3c7;
                    position: absolute;
                    bottom: 0;
                    left: 43%;
                    margin-bottom: -5px;
                    transform: rotate(45deg);
                    -ms-transform: rotate(45deg);
                    -webkit-transform: rotate(45deg);
                }

        .post .views {
            border-bottom: solid 1px #f1f1f1;
            color: #9da6aa;
            font-size: 12px;
            font-family: 'Open Sans Regular', sans-serif;
            text-align: center;
            line-height: 29px;
        }

        .post .time {
            color: #9da6aa;
            font-size: 12px;
            font-family: 'Open Sans Regular', sans-serif;
            text-align: center;
            line-height: 29px;
        }

            .post .time i {
                font-size: 14px;
            }

        .online {
            background-color: green;
            border: 2px solid #ffffff;
            border-radius: 50%;
            height: 16px;
            position: absolute;
            right: 7px;
            top: 24px;
            width: 16px;
        }

        .fav-icon {
            background-color: #f1f1f1;
            border-radius: 50%;
            color: #000;
            font-size: 10px;
            height: 24px;
            line-height: 24px;
            font-style: normal;
            text-align: center;
            width: 24px;
            -webkit-transition: all 0.4s ease;
            -moz-transition: all 0.4s ease;
            -ms-transition: all 0.4s ease;
            -o-transition: all 0.4s ease;
            transition: all 0.4s ease;
        }

        .review {
            width: 48px;
            border-top: solid 1px #f1f1f1;
            margin-top: 12px;
            padding-top: 7px;
        }

        .freelancer-style1 {
            padding: 00px;
        }

        .post .postinfo {
            border-left: solid 1px #f1f1f1;
        }

        .thumb.w90.position-relative.rounded-circle.mb15-md {
            padding: 20px 0px 20px 20px;
        }

        .details.ml20.ml0-md.mb15-md {
            padding: 20px 20px;
        }

        .details .title {
            color: #000;
            font-weight: 600;
            font-size: 18px;
            margin-top: 10px;
            margin-bottom: 10px;
        }

        .details p {
            font-size: 14px;
            color: #101010;
        }

        i.fav-icon.mr3 {
            margin-right: 3px;
        }

        .hero-home13 {
            height: 500px;
        }

        .community-post {
            border-radius: 6px;
            background-color: #fff;
            box-shadow: 0 2px 8px 0 rgba(2, 47, 57, 0.1);
            padding: 23px 30px;
            display: flex;
            align-items: center;
            justify-content: space-between;
            margin-bottom: 20px;
            transition: all 0.3s ease-in-out;
            border: 1px solid transparent;
        }

            .community-post .post-content {
                display: flex;
                align-items: center;
                flex-wrap: wrap;
            }

                .community-post .post-content .author-avatar {
                    width: 40px;
                    margin-right: 25px;
                    border-radius: 50%;
                    overflow: hidden;
                    height: 40px;
                }

                    .community-post .post-content .author-avatar img {
                        max-width: 40px;
                    }

                .community-post .post-content .entry-content {
                    flex: 2;
                }

                    .community-post .post-content .entry-content .post-title {
                        font-size: 18px;
                        font-weight: 500;
                        color: #1d2746;
                        margin-bottom: 0;
                        line-height: 1.7;
                    }

                    .community-post .post-content .entry-content p {
                        margin: 0;
                    }

            .community-post .post-meta-wrapper .post-meta-info {
                margin: 0;
                padding: 0;
                list-style: none;
            }

                .community-post .post-meta-wrapper .post-meta-info li:not(:last-child) {
                    margin-right: 50px;
                }

                .community-post .post-meta-wrapper .post-meta-info li {
                    display: inline-block;
                }

                    .community-post .post-meta-wrapper .post-meta-info li a {
                        display: block;
                        color: #868b99;
                    }

                        .community-post .post-meta-wrapper .post-meta-info li a i {
                            margin-right: 10px;
                        }

        .forum-post-top {
            display: flex;
        }

            .forum-post-top .author-avatar img {
                border-radius: 50%;
                margin-right: 15px;
            }

            .forum-post-top .forum-post-author .author-name {
                font-size: 16px;
                font-weight: 500;
                color: #1d2746;
            }

            .forum-post-top .forum-post-author .forum-author-meta {
                display: flex;
            }

                .forum-post-top .forum-post-author .forum-author-meta .author-badge:first-child {
                    margin-right: 20px;
                }

                .forum-post-top .forum-post-author .forum-author-meta .author-badge svg {
                    margin-top: -5px;
                    margin-right: 5px;
                }

                class="price-widget pt25 pb25 bdrs8", .forum-post-top .forum-post-author .forum-author-meta a {
                    color: #ff7f3e;
                    font-size: 15px;
                }

                .forum-post-top .forum-post-author .forum-author-meta .author-badge i {
                    margin-right: 5px;
                    color: #838793;
                }

        .q-title {
            display: flex;
            padding: 40px 15px 15px 0;
        }

        .question-icon {
            font-size: 34px;
            color: #1d2746;
            margin-right: 15px;
            font-weight: 600;
        }

        .q-title h1 {
            font-size: 20px;
            color: #1d2746;
            line-height: 1.4;
        }

        .q-title .badge {
            margin-left: 10px;
            line-height: 1.4;
            margin-top: 5px;
        }

        .forum-post-content {
            padding-left: 50px;
        }

            .forum-post-content .forum-post-btm {
                display: flex;
                justify-content: space-between;
                border-bottom: 1px solid #e8ecee;
                padding-bottom: 20px;
                padding-top: 30px;
            }

                .forum-post-content .forum-post-btm .taxonomy {
                    font-size: 14px;
                }

                    .forum-post-content .forum-post-btm .taxonomy i, .forum-post-content .forum-post-btm .taxonomy img {
                        margin-right: 10px;
                    }

                    .forum-post-content .forum-post-btm .taxonomy a {
                        color: #838793;
                    }

        .action-button-container.action-btns {
            justify-content: flex-start;
            margin-top: 30px;
        }

        .action-button-container {
            display: flex;
            justify-content: flex-end;
        }

            .action-button-container.action-btns .action_btn {
                height: 30px;
                font-size: 14px;
                line-height: 30px;
                padding: 0 15px;
                font-weight: 400;
            }

            .action-button-container .reply-btn {
                margin-right: 10px;
            }

            .action-button-container .ask-btn {
                box-shadow: none;
                font-size: 16px;
                font-weight: 500;
                padding: 8px 28px;
                margin-top: 2px;
            }

        .action_btn {
            font-size: 16px;
            font-weight: 400;
            color: #fff;
            box-shadow: 0 20px 30px 0 rgba(12, 118, 142, 0.24);
            border-radius: 4px;
            background: #10b3d6;
            display: inline-block;
            padding: 14px 28px;
            transition: color 0.15s ease-in-out, background-color 0.15s ease-in-out, border-color 0.15s ease-in-out, box-shadow 0.18s ease-in-out;
        }



        .action-button-container.action-btns .action_btn {
            height: 30px;
            font-size: 14px;
            line-height: 30px;
            padding: 0 15px;
            font-weight: 400;
        }

        .action-button-container .too-btn {
            background: #fff;
            border: 1px solid #d0d8dc;
            color: #1d2746;
        }

        .action-button-container .ask-btn {
            box-shadow: none;
            font-size: 16px;
            font-weight: 500;
            padding: 8px 28px;
            margin-top: 2px;
        }

        .best-answer {
            background: #f1fdf3;
            padding: 30px 40px 30px 30px;
            margin-top: 60px;
            border-radius: 6px;
        }

            .best-answer .best-ans-content {
                margin-top: 30px;
            }

                .best-answer .best-ans-content .question-icon {
                    margin-top: 10px;
                    margin-right: 20px;
                }

        .question-icon {
            font-size: 34px;
            color: #1d2746;
            margin-right: 15px;
            font-weight: 600;
        }

        .best-answer .best-ans-content p:last-child {
            margin-bottom: 0;
        }

        .best-answer .best-ans-content p {
            font-size: 15px;
        }

        .all-answers {
            margin-top: 20px;
        }

            .all-answers .title {
                font-size: 20px;
                font-weight: 500;
                margin-bottom: 20px;
            }

            .all-answers .forum-comment {
                margin-top: 30px;
            }

        .forum-post-top {
            display: flex;
        }

            .forum-post-top .author-avatar img {
                border-radius: 50%;
                margin-right: 15px;
            }

            .forum-post-top .forum-post-author .author-name {
                font-size: 16px;
                font-weight: 500;
                color: #1d2746;
            }

            .forum-post-top .forum-post-author .forum-author-meta {
                display: flex;
            }

        .all-answers .forum-comment .comment-content {
            margin-left: 60px;
            margin-top: 10px;
            border-bottom: 1px solid #e8ecee;
            padding-bottom: 28px;
        }

        .all-answers .pagination-wrapper {
            background: transparent;
            box-shadow: none;
            margin-top: 15px;
        }

        .pagination-wrapper .post-pagination {
            margin: 0;
            padding: 0;
            list-style: none;
        }

            .pagination-wrapper .post-pagination li:not(:last-child) {
                margin-right: 3px;
            }

            .pagination-wrapper .post-pagination li.pegi-disable {
                display: none;
            }

            .pagination-wrapper .post-pagination li a {
                display: block;
                color: #6b707f;
                height: 35px;
                width: 35px;
                text-align: center;
                line-height: 35px;
                background: #f2f5f6;
                border-radius: 3px;
            }

            .pagination-wrapper .post-pagination li:not(:last-child) {
                margin-right: 3px;
            }

            .pagination-wrapper .post-pagination li {
                display: inline-block;
            }

        .new-side {
            background-color: #ffffff;
            border: 1px solid #E9E9E9;
            border-radius: 4px;
            -webkit-box-shadow: 0px 6px 15px rgba(64, 79, 104, 0.05);
            -moz-box-shadow: 0px 6px 15px rgba(64, 79, 104, 0.05);
            -o-box-shadow: 0px 6px 15px rgba(64, 79, 104, 0.05);
            box-shadow: 0px 6px 15px rgba(64, 79, 104, 0.05);
            margin-bottom: 30px;
            padding: 30px;
            position: relative;
        }

        p {
            color: #000;
        }

        .column {
            position: sticky;
            top: 0;
        }

        .mailchimp-style2 {
            width: 100%;
        }

        .dot {
            width: 3px;
            height: 3px;
            background-color: #000;
            border-radius: 50%;
            margin: 0 6px;
        }.ud-btn4 {
    border-radius: 4px;
    display: inline-block;
    font-family: var(--title-font-family);
    font-weight: 700;
    font-size: 15px;
    font-style: normal;
    letter-spacing: 0em;
    padding: 7px 25px;
    border-radius: 60px !important;
    position: relative;
    overflow: hidden;
    text-align: center;
}
       .like i {
    padding: 10px 10px;
    border: 1px solid #000;
    margin-right: 7px;
    border-radius: 50%;
}
        .like i.active{
            color:#ff7f3e;
        }
        .forum-post-top .forum-post-author .forum-author-meta .author-badge:first-child {
            margin-top: -6px;
        }
        @media (min-width: 320px) and (max-width: 767px) {
    .new-btn-sm-hide {
        display: block !important;
    }
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <section class="our-blog bg-light ">
        <div class="container">
            <div class="row">
                <div class="col-lg-8 col-md-7">

                    <div class="new-side">


                        <!-- Forum post top area -->
                        <div class="row">
                            <div class="col-lg-12">

                                <div class="forum-post-top   justify-content-between align-items-center ">
                                    <div class="d-flex">


                                        <a class="author-avatar" href="#">
                                            <img src="" class="profileImg" height="48" width="48" alt="">
                                        </a>
                                        <div class="forum-post-author">
                                            <a class="author-name" href="#"><span class="username"></span></a>
                                            <div class="forum-author-meta">

                                                <div class="author-badge">
                                                    <span>Member
                                                    </span>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="like">
                                        <i class="fa-solid fa-thumbs-up cls"></i>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="q-title">
                            <span class="question-icon" title="Question">Q:</span>
                            <h1 class="strTitle"></h1>
                        </div>
                        <!-- Forum post content -->

                        <div class="forum-post-content">
                            <div class="content text-start">
                                <p class="strDescription"></p>
                            </div>


                        </div>
                        <div class="forum-post-content new-left">
                            <div class="action-button-container action-btns d-flex justify-content-between ">
                                <div class="">
                                    <i class="fa-solid fa-calendar-days"></i>
                                    <a href="JavaScript:void(0)" class="strLastseen"><span class="dot"></span></a>
                                </div>
                                <div class="">
                                    <a href="JavaScript:void(0)" class="ud-btn4 px-3 ">Comments(<span class="CommentCount"></span>)</a>
                                </div>
                            </div>

                        </div>

                        <!-- Best answer -->
                        <!-- All answer -->
                    </div>

                    <%-- <div class="new-side new-flex d-flex align-items-center">
                        <a class="author-avatar" href="#">
                            <img src="/images/blog/comments-1.png" height="48" width="48" alt="">
                        </a>
                        <div class="mailchimp-style2 default-box-shadow7 mx-xl-4">
                            <input type="text" class="form-control txtComment" id="txtComment" placeholder="Your Reply">
                            <button type="submit" class="ud-btn btn-thm2 new-btn-sm-hide btnCmt" id="btnCmt">Post Reply</button>
                            <span class="spncmt"></span>
                        </div>
                    </div>--%>
                    <div class="pb30 new-flex">
                        <div class="mailchimp-style2">
                            <span class="spncmt text-danger"></span>
                            <textarea name="Text1" cols="40" class="txtComment" id="txtComment" rows="5" placeholder="Write your Message..."></textarea>
                        </div>
                        <div class="d-flex justify-content-end mt-3">
                            <button class="ud-btn btn-white text-dark me-2 btnClear" id="btnClear" type="submit">Clear</button>
                            <button type="submit" class="ud-btn btn-thm2 new-btn-sm-hide btnCmt" id="btnCmt">Reply</button>
                        </div>
                    </div>

                    <div class="new-side">

                        <div class="all-answers">
                            <h3 class="title">All Replies</h3>

                            <div id="commentSection" class="strComments">
                            </div>

                            <%-- <div class="forum-comment">
                                <div class="forum-post-top">
                                    <a class="author-avatar" href="#">
                                        <img src="/new-img/cp1.png" alt="author avatar">
                                    </a>
                                    <div class="forum-post-author">
                                        <a class="author-name" href="#">Eh Jewel</a>
                                        <div class="forum-author-meta">

                                            <div class="author-badge">
                                                <i class="fa-solid fa-calendar-days"></i>
                                                <a href="/">January 16 at 10:32 PM</a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="comment-content">
                                    <p>Cheeky chap jolly good mufty a load of old tosh I don't want no agro a chinwag amongst tickety-boo, tosser victoria sponge horse play happy days give us a bell nice one cup of tea young delinquent wellies, cockup absolutely bladdered barmy bleeding.!</p>
                                </div>
                            </div>
                            <div class="forum-comment">
                                <div class="forum-post-top">
                                    <a class="author-avatar" href="#">
                                        <img src="/new-img/cp1.png" alt="author avatar">
                                    </a>
                                    <div class="forum-post-author">
                                        <a class="author-name" href="#">Parsley Montana</a>
                                        <div class="forum-author-meta">

                                            <div class="author-badge">
                                                <i class="fa-solid fa-calendar-days"></i>
                                                <a href="/">February 16 at 5:32 PM</a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="comment-content">
                                    <p>That cockup bleeding skive off such a fibber cup of char squiffy car boot, lemon squeezy lavatory Richard jolly good tosser excuse my French, mush barney.</p>
                                  
                                </div>
                            </div>

                            <div class="forum-comment">
                                <div class="forum-post-top">
                                    <a class="author-avatar" href="#">
                                        <img src="/new-img/cp1.png" alt="author avatar">
                                    </a>
                                    <div class="forum-post-author">
                                        <a class="author-name" href="#">Giles Posture</a>
                                        <div class="forum-author-meta">

                                            <div class="author-badge">
                                                <i class="fa-solid fa-calendar-days"></i>
                                                <a href="/">January 16 at 10:32 PM</a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="comment-content">
                                    <p>Cheeky chap jolly good mufty a load of old tosh I don't want no agro a chinwag amongst tickety-boo, tosser victoria sponge horse play happy days give us a bell nice one cup.!</p>
                                  
                                </div>
                            </div>

                            <div class="forum-comment">
                                <div class="forum-post-top">
                                    <a class="author-avatar" href="#">
                                        <img src="/new-img/cp1.png" alt="author avatar">
                                    </a>
                                    <div class="forum-post-author">
                                        <a class="author-name" href="#">Norman Gordon</a>
                                        <div class="forum-author-meta">

                                            <div class="author-badge">
                                                <i class="fa-solid fa-calendar-days"></i>
                                                <a href="/">January 16 at 10:32 PM</a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="comment-content">
                                    <p>Cheeky chap jolly good mufty a load of old tosh I don't want no agro a chinwag amongst tickety-boo, tosser victoria sponge horse play happy days give us a bell nice one cup of tea young delinquent wellies, cockup absolutely bladdered barmy bleeding.!</p>
                                  
                                </div>
                            </div>--%>
                        </div>
                    </div>
                </div>
                <!-- /.col-lg-8 -->






                <div class="col-lg-3 offset-lg-1 col-md-5">
                    <div class="column ">
                        <div class="blog-sidebar ms-lg-auto">
                            <div class="price-widget">
                                <div class="navtab-style1">
                                    <nav>
                                        <div class="nav nav-tabs active mb20" id="nav-tab2p" role="tablist">
                                            <button class="nav-link active fw500" id="nav-item1p-tab" data-bs-toggle="tab" data-bs-target="#nav-item1p" type="button" role="tab" aria-controls="nav-item1p" aria-selected="true">Related Topics</button>
                                        </div>
                                    </nav>
                                    <div class="" id="nav-tabContent">
                                        <div class="tab-pane show active" id="nav-item1p" role="tabpanel" aria-labelledby="nav-item1p-tab">
                                            <div class="freelancer-style1  bdr0 hover-box-shadow row ms-0 align-items-start">
                                                <div class="col-xl-12 px-0">
                                                    <div class="">

                                                        <div class="blocktxt">
                                                            <%=strCat %>
                                                            <%-- <ul class="cats pl0">
                                                                <li><a href="#">Trading for Money <span class="badge pull-right">20</span></a></li>
                                                                <li><a href="#">Vault Keys Giveway <span class="badge pull-right">10</span></a></li>
                                                                <li><a href="#">Misc Guns Locations <span class="badge pull-right">50</span></a></li>
                                                                <li><a href="#">Looking for Players <span class="badge pull-right">36</span></a></li>
                                                                <li><a href="#">Stupid Bugs &amp; Solves <span class="badge pull-right">41</span></a></li>
                                                                <li><a href="#">Video &amp; Audio Drivers <span class="badge pull-right">11</span></a></li>
                                                                <li><a href="#">2K Official Forums <span class="badge pull-right">5</span></a></li>
                                                            </ul>--%>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                            
                        </div>
                    </div>

                </div>
            </div>

        <label class="d-none lblguid"><%=RouteData.Values["furl"] %></label>
        </div>
         <%--  <div class="new-fade">
    <div class="modal fade" id="exampleModal1" data-bs-backdrop="static" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-body text-center p-5">
                    <h2>Login to Continue</h2>
                    <a href="/login.aspx" class="ud-btn btn-thm mt-4 default-box-shadow2">
                        Login <i class="fal fa-arrow-right-long"></i>
                    </a>
                </div>
            </div>
        </div>
    </div>
</div>--%>
    </section>

    <script src="/js/jquery-3.6.0.min.js"></script>
    <script src="/js/snackbar/snackbar.min.js"></script>
    <script src="/js/forum-details.js"></script>
    <script>
        $(window).on('load', function () {
            //var isLoggedIn = document.cookie.indexOf('med_uid=') !== -1;

            //if (!isLoggedIn) {
            //    $('#exampleModal1').modal('show');
            //}
            $('#exampleModal1').modal('show');
        });
    </script>

</asp:Content>

