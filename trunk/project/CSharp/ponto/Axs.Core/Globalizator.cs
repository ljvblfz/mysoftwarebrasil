// 
//  Copyright (c) 2011, WebAula S/A 
//  All rights reserved.
//
//  Authors: 
//               
//           * Ivan Paulovich (ivan@100loop.com)
//           Blog: http://www.100loop.com/          
//           Messenger: ivanpaulovich@hotmail.com 
//               
//           * Phillipe Duarte Gori (pdgori@100loop.com)
//           Blog: http://www.100loop.com/          
//           Messenger: pdgori@hotmail.com 
//

using System.Globalization;
using System.Web;
using Webaula.Cache;

namespace PontoEncontro.Infrastructure
{
    /// <summary>
    /// Globaliza expressões
    /// </summary>
    public static class Globalizator
    {
        /// <summary>
        /// Localiza um texto para o idioma em execução da aplicação
        /// </summary>
        /// <param name="text">ID da mensagem a ser globalizada</param>
        /// <returns>String com o texto globalizado</returns>
        public static string Localize(string text)
        {
            string cacheKey = string.Format(CultureInfo.InvariantCulture, "expressionfor{0}", text);

            string expression = "E" + text;

            if (!CacheHelper.Exists(cacheKey))
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies["Ticket"];

                if (cookie != null)
                {
                    CacheHelper.Add(expression, cacheKey);
                    //var client = new Management.Globalization.ServiceClient();

                    //if (client.GetString(cookie.Value, text, out expression))
                    //    CacheHelper.Add(expression, cacheKey);
                }
            }
            else
                CacheHelper.Get(cacheKey, out expression);

            return expression;
        }

        /// <summary>
        ///  Label de campo obrigatorio
        /// </summary>
        public static string RequiredFields
        {
            get
            {
                 return Localize("Campos  obrigatórios");
            }
        }
        
        public static string AccessFinishesOnRequired
        {
            get
            {
                return Localize("FinishesOn é obrigatório");
            }
        }

        public static string AccessStarsOnRequired
        {
            get
            {
                return Localize("StarsOn é obrigatório");
            }
        }
        
        public static string ActionCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string ActionCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }

        public static string ActionNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 50 caracteres.");
            }
        }

        public static string ActionNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }
        
        public static string ActivityImagePathStringLength
        {
            get
            {
                return Localize("O campo ImagePath aceita no máximo 255 caracteres.");
            }
        }
        
        public static string ActivityNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 255 caracteres.");
            }
        }

        public static string ActivityNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }

        public static string ActivityPositionRequired
        {
            get
            {
                return Localize("Position é obrigatório");
            }
        }
        
        public static string AlertCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string AlertCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }
        
        public static string AlertIsActiveRequired
        {
            get
            {
                return Localize("IsActive é obrigatório");
            }
        }

        public static string AlertMessageStringLength
        {
            get
            {
                return Localize("O campo Message aceita no máximo 500 caracteres.");
            }
        }

        public static string AlertMessageRequired
        {
            get
            {
                return Localize("Message é obrigatório");
            }
        }

        public static string AlertStartsOnRequired
        {
            get
            {
                return Localize("StartsOn é obrigatório");
            }
        }

        public static string AlertTitleStringLength
        {
            get
            {
                return Localize("O campo Title aceita no máximo 50 caracteres.");
            }
        }

        public static string AlertTitleRequired
        {
            get
            {
                return Localize("Title é obrigatório");
            }
        }

        public static string AlertAreaAlertIdRequired
        {
            get
            {
                return Localize("AlertId é obrigatório");
            }
        }
        
        public static string AlertAreaAreaIdRequired
        {
            get
            {
                return Localize("AreaId é obrigatório");
            }
        }
        
        public static string AlertClassAlertIdRequired
        {
            get
            {
                return Localize("AlertId é obrigatório");
            }
        }
        
        public static string AlertClassClassIdRequired
        {
            get
            {
                return Localize("ClassId é obrigatório");
            }
        }
        
        public static string AlertCommunityAlertIdRequired
        {
            get
            {
                return Localize("AlertId é obrigatório");
            }
        }
        
        public static string AlertCommunityCommunityIdRequired
        {
            get
            {
                return Localize("CommunityId é obrigatório");
            }
        }
        
        public static string AlertCourseAlertIdRequired
        {
            get
            {
                return Localize("AlertId é obrigatório");
            }
        }
        
        public static string AlertCourseCourseIdRequired
        {
            get
            {
                return Localize("CourseId é obrigatório");
            }
        }
        
        public static string AlertProfileAlertIdRequired
        {
            get
            {
                return Localize("AlertId é obrigatório");
            }
        }
        
        public static string AlertProfileProfileIdRequired
        {
            get
            {
                return Localize("ProfileId é obrigatório");
            }
        }
        
        public static string AlertProgramAlertIdRequired
        {
            get
            {
                return Localize("AlertId é obrigatório");
            }
        }
        
        public static string AlertProgramProgramIdRequired
        {
            get
            {
                return Localize("ProgramId é obrigatório");
            }
        }
        
        public static string AlertUnitAlertIdRequired
        {
            get
            {
                return Localize("AlertId é obrigatório");
            }
        }
        
        public static string AlertUnitUnitIdRequired
        {
            get
            {
                return Localize("UnitId é obrigatório");
            }
        }
        
        public static string AppointmentApprovedByRequired
        {
            get
            {
                return Localize("ApprovedBy é obrigatório");
            }
        }

        public static string AppointmentApprovedOnRequired
        {
            get
            {
                return Localize("ApprovedOn é obrigatório");
            }
        }

        public static string AppointmentCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string AppointmentCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }

        public static string AppointmentDescriptionStringLength
        {
            get
            {
                return Localize("O campo Description aceita no máximo 500 caracteres.");
            }
        }

        public static string AppointmentDescriptionRequired
        {
            get
            {
                return Localize("Description é obrigatório");
            }
        }

        public static string AppointmentFinishesOnRequired
        {
            get
            {
                return Localize("FinishesOn é obrigatório");
            }
        }

        public static string AppointmentNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 100 caracteres.");
            }
        }

        public static string AppointmentNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }

        public static string AppointmentRecurrenceIdRequired
        {
            get
            {
                return Localize("RecurrenceId é obrigatório");
            }
        }

        public static string AppointmentStartsOnRequired
        {
            get
            {
                return Localize("StartsOn é obrigatório");
            }
        }

        public static string AppointmentAppointCategoryAppointmentCategoryIdRequired
        {
            get
            {
                return Localize("AppointmentCategoryId é obrigatório");
            }
        }
        
        public static string AppointmentAppointCategoryAppointmentIdRequired
        {
            get
            {
                return Localize("AppointmentId é obrigatório");
            }
        }
        
        public static string AppointmentClassAppointmentIdRequired
        {
            get
            {
                return Localize("AppointmentId é obrigatório");
            }
        }
        
        public static string AppointmentClassClassIdRequired
        {
            get
            {
                return Localize("ClassId é obrigatório");
            }
        }
        
        public static string AppointmentCommunityAppointmentIdRequired
        {
            get
            {
                return Localize("AppointmentId é obrigatório");
            }
        }
        
        public static string AppointmentCommunityCommunityIdRequired
        {
            get
            {
                return Localize("CommunityId é obrigatório");
            }
        }
        
        public static string AppointmentCourseAppointmentIdRequired
        {
            get
            {
                return Localize("AppointmentId é obrigatório");
            }
        }
        
        public static string AppointmentCourseCourseIdRequired
        {
            get
            {
                return Localize("CourseId é obrigatório");
            }
        }
        
        public static string AppointmentProfileAppointmentIdRequired
        {
            get
            {
                return Localize("AppointmentId é obrigatório");
            }
        }
        
        public static string AppointmentProfileProfileIdRequired
        {
            get
            {
                return Localize("ProfileId é obrigatório");
            }
        }
        
        public static string AppointmentProgramAppointmentIdRequired
        {
            get
            {
                return Localize("AppointmentId é obrigatório");
            }
        }
        
        public static string AppointmentProgramProgramIdRequired
        {
            get
            {
                return Localize("ProgramId é obrigatório");
            }
        }
        
        public static string AppointmentUnitAppointmentIdRequired
        {
            get
            {
                return Localize("AppointmentId é obrigatório");
            }
        }
        
        public static string AppointmentUnitUnitIdRequired
        {
            get
            {
                return Localize("UnitId é obrigatório");
            }
        }
                
        public static string AppointmentCategoryNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 50 caracteres.");
            }
        }

        public static string AppointmentCategoryNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }
        
        public static string AppointmentRecurrencePeriodRequired
        {
            get
            {
                return Localize("Period é obrigatório");
            }
        }
        
        public static string AreaCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string AreaDescriptionStringLength
        {
            get
            {
                return Localize("O campo Description aceita no máximo 200 caracteres.");
            }
        }
        
        public static string AreaNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 50 caracteres.");
            }
        }

        public static string AreaNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }

        public static string AreaThemeIdRequired
        {
            get
            {
                return Localize("ThemeId é obrigatório");
            }
        }
        
        public static string AssessmentApprovalScoreRequired
        {
            get
            {
                return Localize("ApprovalScore é obrigatório");
            }
        }
        
        public static string AssessmentIsPublicRequired
        {
            get
            {
                return Localize("IsPublic é obrigatório");
            }
        }

        public static string AssessmentIsUsedOnFinalScoreRequired
        {
            get
            {
                return Localize("IsUsedOnFinalScore é obrigatório");
            }
        }

        public static string AssessmentLearningObjectIdRequired
        {
            get
            {
                return Localize("LearningObjectId é obrigatório");
            }
        }
        
        public static string AssessmentReSortOnErrorRequired
        {
            get
            {
                return Localize("ReSortOnError é obrigatório");
            }
        }

        public static string AssessmentResortOnInterruptionRequired
        {
            get
            {
                return Localize("ResortOnInterruption é obrigatório");
            }
        }
        
        public static string AssessmentScoreRequired
        {
            get
            {
                return Localize("Score é obrigatório");
            }
        }

        public static string AssessmentSortByCategoryRequired
        {
            get
            {
                return Localize("SortByCategory é obrigatório");
            }
        }

        public static string AssessmentSortByLevelStringLength
        {
            get
            {
                return Localize("O campo SortByLevel aceita no máximo 18 caracteres.");
            }
        }
        
        public static string AssessmentSortOnlyNewQuestionsRequired
        {
            get
            {
                return Localize("SortOnlyNewQuestions é obrigatório");
            }
        }

        public static string AssessmentSortQuestionByTopicRequired
        {
            get
            {
                return Localize("SortQuestionByTopic é obrigatório");
            }
        }

        public static string AssessmentSortQuestionsRequired
        {
            get
            {
                return Localize("SortQuestions é obrigatório");
            }
        }
        
        public static string AssessmentSubstituteAssessmentIdRequired
        {
            get
            {
                return Localize("SubstituteAssessmentID é obrigatório");
            }
        }

        public static string AssessmentTypeRequired
        {
            get
            {
                return Localize("Type é obrigatório");
            }
        }

        public static string AssessmentAccessAccessIdRequired
        {
            get
            {
                return Localize("AccessId é obrigatório");
            }
        }
        
        public static string AssessmentAccessAssessmentIdRequired
        {
            get
            {
                return Localize("AssessmentId é obrigatório");
            }
        }
        
        public static string AssessmentAttemptsAttemptNumberRequired
        {
            get
            {
                return Localize("AttemptNumber é obrigatório");
            }
        }
        
        public static string AssessmentAttemptsScoreRequired
        {
            get
            {
                return Localize("Score é obrigatório");
            }
        }

        public static string AssessmentAttemptsStartsOnRequired
        {
            get
            {
                return Localize("StartsOn é obrigatório");
            }
        }

        public static string AssessmentAttemptsTrainingRealizationIdRequired
        {
            get
            {
                return Localize("TrainingRealizationId é obrigatório");
            }
        }

        public static string AssessmentItemTagAssessmentQuestionIdRequired
        {
            get
            {
                return Localize("AssessmentQuestionId é obrigatório");
            }
        }
        
        public static string AssessmentItemTagTagIdRequired
        {
            get
            {
                return Localize("TagId é obrigatório");
            }
        }
        
        public static string AssessmentQuestionContentStringLength
        {
            get
            {
                return Localize("O campo Content aceita no máximo 255 caracteres.");
            }
        }

        public static string AssessmentQuestionContentRequired
        {
            get
            {
                return Localize("Content é obrigatório");
            }
        }

        public static string AssessmentQuestionDifficultyLevelIdRequired
        {
            get
            {
                return Localize("DifficultyLevelId é obrigatório");
            }
        }

        public static string AssessmentQuestionImagePathStringLength
        {
            get
            {
                return Localize("O campo ImagePath aceita no máximo 255 caracteres.");
            }
        }

        public static string AssessmentQuestionNulledItemRequired
        {
            get
            {
                return Localize("NulledItem é obrigatório");
            }
        }

        public static string AssessmentQuestionOnlineAssessmentIdRequired
        {
            get
            {
                return Localize("OnlineAssessmentId é obrigatório");
            }
        }

        public static string AssessmentQuestionQuestionCategoryIdRequired
        {
            get
            {
                return Localize("QuestionCategoryId é obrigatório");
            }
        }

        public static string AssessmentQuestionTypeRequired
        {
            get
            {
                return Localize("Type é obrigatório");
            }
        }
        
        public static string AttendanceListLocalClassroomIdRequired
        {
            get
            {
                return Localize("LocalClassroomId é obrigatório");
            }
        }

        public static string AttendanceListPropertyModelStringLength
        {
            get
            {
                return Localize("O campo PropertyModel aceita no máximo 500 caracteres.");
            }
        }

        public static string AttendanceListPropertyModelRequired
        {
            get
            {
                return Localize("PropertyModel é obrigatório");
            }
        }

        public static string AttendanceListTutorIdRequired
        {
            get
            {
                return Localize("TutorId é obrigatório");
            }
        }
        
        public static string BankIDStringLength
        {
            get
            {
                return Localize("O campo ID aceita no máximo 10 caracteres.");
            }
        }

        public static string BankIDRequired
        {
            get
            {
                return Localize("ID é obrigatório");
            }
        }

        public static string BankNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 50 caracteres.");
            }
        }

        public static string BankNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }

        public static string BannerAreaIdRequired
        {
            get
            {
                return Localize("AreaId é obrigatório");
            }
        }
        
        public static string BannerDescriptionStringLength
        {
            get
            {
                return Localize("O campo Description aceita no máximo 500 caracteres.");
            }
        }
        
        public static string BannerFileStringLength
        {
            get
            {
                return Localize("O campo File aceita no máximo 250 caracteres.");
            }
        }

        public static string BannerFileRequired
        {
            get
            {
                return Localize("File é obrigatório");
            }
        }

        public static string BannerIsActiveRequired
        {
            get
            {
                return Localize("IsActive é obrigatório");
            }
        }

        public static string BannerNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 50 caracteres.");
            }
        }

        public static string BannerNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }

        public static string BannerUrlRequired
        {
            get
            {
                return Localize("Url é obrigatório");
            }
        }

        public static string BannerUrlStringLength
        {
            get
            {
                return Localize("O campo Url aceita no máximo 250 caracteres.");
            }
        }

        public static string BatchSetupCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }

        public static string BlogPostBlogPostCategoryIdRequired
        {
            get
            {
                return Localize("BlogPostCategoryId é obrigatório");
            }
        }
        
        public static string BlogPostCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string BlogPostCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }
        
        public static string BlogPostStartsOnRequired
        {
            get
            {
                return Localize("StartsOn é obrigatório");
            }
        }

        public static string BlogPostTitleStringLength
        {
            get
            {
                return Localize("O campo Title aceita no máximo 200 caracteres.");
            }
        }

        public static string BlogPostTitleRequired
        {
            get
            {
                return Localize("Title é obrigatório");
            }
        }

        public static string BlogPostTagBlogPostIdRequired
        {
            get
            {
                return Localize("BlogPostId é obrigatório");
            }
        }
        
        public static string BlogPostTagTagIdRequired
        {
            get
            {
                return Localize("TagId é obrigatório");
            }
        }
        
        public static string BlogPostCategoryCategoryStringLength
        {
            get
            {
                return Localize("O campo Category aceita no máximo 100 caracteres.");
            }
        }

        public static string BlogPostCategoryCategoryRequired
        {
            get
            {
                return Localize("Category é obrigatório");
            }
        }

        public static string BlogPostCategoryCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string BlogPostCategoryCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }
        
        public static string BlogPostCommentBlogPostIdRequired
        {
            get
            {
                return Localize("BlogPostId é obrigatório");
            }
        }

        public static string BlogPostCommentCommentStringLength
        {
            get
            {
                return Localize("O campo Comment aceita no máximo -1 caracteres.");
            }
        }

        public static string BlogPostCommentCommentRequired
        {
            get
            {
                return Localize("Comment é obrigatório");
            }
        }

        public static string BlogPostCommentCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string BlogPostCommentCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }

        public static string BlogPostCommentIsApprovedRequired
        {
            get
            {
                return Localize("IsApproved é obrigatório");
            }
        }

        public static string CardActivatedOnRequired
        {
            get
            {
                return Localize("ActivatedOn é obrigatório");
            }
        }
        
        public static string CardCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string CardCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }

        public static string CardExpiresOnRequired
        {
            get
            {
                return Localize("ExpiresOn é obrigatório");
            }
        }

        public static string CardProductionLineRequired
        {
            get
            {
                return Localize("ProductionLine é obrigatório");
            }
        }

        public static string CardUsedOnRequired
        {
            get
            {
                return Localize("UsedOn é obrigatório");
            }
        }

        public static string CardClassCardIdRequired
        {
            get
            {
                return Localize("CardId é obrigatório");
            }
        }
        
        public static string CardClassClassIdRequired
        {
            get
            {
                return Localize("ClassId é obrigatório");
            }
        }
        
        public static string CardCourseCardIdRequired
        {
            get
            {
                return Localize("CardId é obrigatório");
            }
        }
        
        public static string CardCourseCourseIdRequired
        {
            get
            {
                return Localize("CourseId é obrigatório");
            }
        }
        
        public static string CardProgramCardIdRequired
        {
            get
            {
                return Localize("CardId é obrigatório");
            }
        }
        
        public static string CardProgramProgramIdRequired
        {
            get
            {
                return Localize("ProgramId é obrigatório");
            }
        }
        
        public static string CertificateContentStringLength
        {
            get
            {
                return Localize("O campo Content aceita no máximo 500 caracteres.");
            }
        }

        public static string CertificateContentRequired
        {
            get
            {
                return Localize("Content é obrigatório");
            }
        }

        public static string CertificateIsParticipationCertificateRequired
        {
            get
            {
                return Localize("IsParticipationCertificate é obrigatório");
            }
        }

        public static string CertificateIsPerformanceCertificateRequired
        {
            get
            {
                return Localize("IsPerformanceCertificate é obrigatório");
            }
        }

        public static string CertificatePathStringLength
        {
            get
            {
                return Localize("O campo Path aceita no máximo 255 caracteres.");
            }
        }

        public static string CertificatePathRequired
        {
            get
            {
                return Localize("Path é obrigatório");
            }
        }

        public static string CertificateRulesStringLength
        {
            get
            {
                return Localize("O campo Rules aceita no máximo 255 caracteres.");
            }
        }

        public static string CertificateRulesRequired
        {
            get
            {
                return Localize("Rules é obrigatório");
            }
        }

        public static string CertificateAreaAreaIdRequired
        {
            get
            {
                return Localize("AreaId é obrigatório");
            }
        }
        
        public static string CertificateAreaCertificateIdRequired
        {
            get
            {
                return Localize("CertificateId é obrigatório");
            }
        }
        
        public static string CertificateClassCertificateIdRequired
        {
            get
            {
                return Localize("CertificateId é obrigatório");
            }
        }
        
        public static string CertificateClassClassIdRequired
        {
            get
            {
                return Localize("ClassId é obrigatório");
            }
        }
        
        public static string CertificateCommunityCertificateIdRequired
        {
            get
            {
                return Localize("CertificateId é obrigatório");
            }
        }
        
        public static string CertificateCommunityCommunityIdRequired
        {
            get
            {
                return Localize("CommunityId é obrigatório");
            }
        }
        
        public static string CertificateCourseCertificateIdRequired
        {
            get
            {
                return Localize("CertificateId é obrigatório");
            }
        }
        
        public static string CertificateCourseCourseIdRequired
        {
            get
            {
                return Localize("CourseId é obrigatório");
            }
        }
        
        public static string CertificateProgramCertificateIdRequired
        {
            get
            {
                return Localize("CertificateId é obrigatório");
            }
        }
        
        public static string CertificateProgramProgramIdRequired
        {
            get
            {
                return Localize("ProgramId é obrigatório");
            }
        }
        
        public static string CertificateUnitCertificateIdRequired
        {
            get
            {
                return Localize("CertificateId é obrigatório");
            }
        }
        
        public static string CertificateUnitUnitIdRequired
        {
            get
            {
                return Localize("UnitId é obrigatório");
            }
        }
        
        public static string ChangeLogActionStringLength
        {
            get
            {
                return Localize("O campo Action aceita no máximo 50 caracteres.");
            }
        }

        public static string ChangeLogActionRequired
        {
            get
            {
                return Localize("Action é obrigatório");
            }
        }
        
        public static string ChangeLogChangeTextStringLength
        {
            get
            {
                return Localize("O campo ChangeText aceita no máximo -1 caracteres.");
            }
        }

        public static string ChangeLogChangeTextRequired
        {
            get
            {
                return Localize("ChangeText é obrigatório");
            }
        }

        public static string ChangeLogDateRequired
        {
            get
            {
                return Localize("Date é obrigatório");
            }
        }

        public static string ChangeLogPropertyLogIdRequired
        {
            get
            {
                return Localize("PropertyLogId é obrigatório");
            }
        }

        public static string ChangeLogTypeLogIdRequired
        {
            get
            {
                return Localize("TypeLogId é obrigatório");
            }
        }

        public static string ChangeLogUserIdRequired
        {
            get
            {
                return Localize("UserId é obrigatório");
            }
        }
        
        public static string ChatMessageChatSessionInstanceIdRequired
        {
            get
            {
                return Localize("ChatSessionInstanceId é obrigatório");
            }
        }

        public static string ChatMessageExpressionIdRequired
        {
            get
            {
                return Localize("ExpressionId é obrigatório");
            }
        }

        public static string ChatMessageIsSystemMessageRequired
        {
            get
            {
                return Localize("IsSystemMessage é obrigatório");
            }
        }

        public static string ChatMessageIsVisibleRequired
        {
            get
            {
                return Localize("IsVisible é obrigatório");
            }
        }

        public static string ChatMessageMessageTextStringLength
        {
            get
            {
                return Localize("O campo MessageText aceita no máximo 500 caracteres.");
            }
        }

        public static string ChatMessageMessageTextRequired
        {
            get
            {
                return Localize("MessageText é obrigatório");
            }
        }
        
        public static string ChatMessageModerationStatusRequired
        {
            get
            {
                return Localize("ModerationStatus é obrigatório");
            }
        }

        public static string ChatMessageModeratorIdRequired
        {
            get
            {
                return Localize("ModeratorId é obrigatório");
            }
        }

        public static string ChatMessageReceiverIdRequired
        {
            get
            {
                return Localize("ReceiverId é obrigatório");
            }
        }

        public static string ChatMessageSenderIdRequired
        {
            get
            {
                return Localize("SenderId é obrigatório");
            }
        }

        public static string ChatMessageSentOnRequired
        {
            get
            {
                return Localize("SentOn é obrigatório");
            }
        }

        public static string ChatMessageUIGuidStringLength
        {
            get
            {
                return Localize("O campo UIGuid aceita no máximo 50 caracteres.");
            }
        }

        public static string ChatMessageUIGuidRequired
        {
            get
            {
                return Localize("ChatMessageUIGuid é obrigatório");
            }
        }
        
        public static string ChatScheduleBatchSetupIdRequired
        {
            get
            {
                return Localize("BatchSetupId é obrigatório");
            }
        }
        
        public static string ChatScheduleChatSessionIdRequired
        {
            get
            {
                return Localize("ChatSessionId é obrigatório");
            }
        }

        public static string ChatScheduleCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string ChatScheduleCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }

        public static string ChatScheduleDescriptionStringLength
        {
            get
            {
                return Localize("O campo Description aceita no máximo 500 caracteres.");
            }
        }

        public static string ChatScheduleIsActiveRequired
        {
            get
            {
                return Localize("IsActive é obrigatório");
            }
        }

        public static string ChatScheduleNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 100 caracteres.");
            }
        }

        public static string ChatScheduleNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }

        public static string ChatScheduleSentNotificationRequired
        {
            get
            {
                return Localize("SentNotification é obrigatório");
            }
        }

        public static string ChatScheduleStartsOnRequired
        {
            get
            {
                return Localize("StartsOn é obrigatório");
            }
        }

        public static string ChatScheduleClassChatScheduleIdRequired
        {
            get
            {
                return Localize("ChatScheduleId é obrigatório");
            }
        }
        
        public static string ChatScheduleClassClassIdRequired
        {
            get
            {
                return Localize("ClassId é obrigatório");
            }
        }
        
        public static string ChatScheduleCommunityChatScheduleIdRequired
        {
            get
            {
                return Localize("ChatScheduleId é obrigatório");
            }
        }
        
        public static string ChatScheduleCommunityCommunityIdRequired
        {
            get
            {
                return Localize("CommunityId é obrigatório");
            }
        }
        
        public static string ChatScheduleCourseChatScheduleIdRequired
        {
            get
            {
                return Localize("ChatScheduleId é obrigatório");
            }
        }
        
        public static string ChatScheduleCourseCourseIdRequired
        {
            get
            {
                return Localize("CourseId é obrigatório");
            }
        }
        
        public static string ChatScheduleProfileChatScheduleIdRequired
        {
            get
            {
                return Localize("ChatScheduleId é obrigatório");
            }
        }
        
        public static string ChatScheduleProfileProfileIdRequired
        {
            get
            {
                return Localize("ProfileId é obrigatório");
            }
        }
        
        public static string ChatScheduleProgramChatScheduleIdRequired
        {
            get
            {
                return Localize("ChatScheduleId é obrigatório");
            }
        }
        
        public static string ChatScheduleProgramProgramIdRequired
        {
            get
            {
                return Localize("ProgramId é obrigatório");
            }
        }
        
        public static string ChatScheduleUnitChatScheduleIdRequired
        {
            get
            {
                return Localize("ChatScheduleId é obrigatório");
            }
        }
        
        public static string ChatScheduleUnitUnitIdRequired
        {
            get
            {
                return Localize("UnitId é obrigatório");
            }
        }
        
        public static string ChatScheduleUserChatScheduleIdRequired
        {
            get
            {
                return Localize("ChatScheduleId é obrigatório");
            }
        }
        
        public static string ChatScheduleUserUserIdRequired
        {
            get
            {
                return Localize("UserId é obrigatório");
            }
        }
        
        public static string ChatSessionChatTypeRequired
        {
            get
            {
                return Localize("ChatType é obrigatório");
            }
        }

        public static string ChatSessionInstanceChatSessionIdRequired
        {
            get
            {
                return Localize("ChatSessionId é obrigatório");
            }
        }
        
        public static string ChatSessionInstanceStartsOnRequired
        {
            get
            {
                return Localize("StartsOn é obrigatório");
            }
        }

        public static string ChatSessionInstanceUserIdRequired
        {
            get
            {
                return Localize("UserId é obrigatório");
            }
        }
        
        public static string ChatUserNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 50 caracteres.");
            }
        }

        public static string ChatUserNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }

        public static string ChatUserRoleRequired
        {
            get
            {
                return Localize("Role é obrigatório");
            }
        }

        public static string ChatUserUserIdRequired
        {
            get
            {
                return Localize("UserId é obrigatório");
            }
        }

        public static string ChatUserInstanceChatSessionInstanceIdRequired
        {
            get
            {
                return Localize("ChatSessionInstanceId é obrigatório");
            }
        }

        public static string ChatUserInstanceChatUserIdRequired
        {
            get
            {
                return Localize("ChatUserId é obrigatório");
            }
        }
        
        public static string ChatUserInstanceStartedOnRequired
        {
            get
            {
                return Localize("StartedOn é obrigatório");
            }
        }
        
        public static string CityIsCapitalRequired
        {
            get
            {
                return Localize("IsCapital é obrigatório");
            }
        }

        public static string CityNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 50 caracteres.");
            }
        }

        public static string CityNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }

        public static string CityStateIdRequired
        {
            get
            {
                return Localize("StateId é obrigatório");
            }
        }

        public static string ClassAllowPreRegistrationRequired
        {
            get
            {
                return Localize("AllowPreRegistration é obrigatório");
            }
        }
        
        public static string ClassBatchSetupIdRequired
        {
            get
            {
                return Localize("BatchSetupID é obrigatório");
            }
        }
        
        public static string ClassClassNameStringLength
        {
            get
            {
                return Localize("O campo ClassName aceita no máximo 255 caracteres.");
            }
        }

        public static string ClassClassNameRequired
        {
            get
            {
                return Localize("ClassName é obrigatório");
            }
        }

        public static string ClassClassRecyclingRequired
        {
            get
            {
                return Localize("ClassRecycling é obrigatório");
            }
        }

        public static string ClassCoordenationIdRequired
        {
            get
            {
                return Localize("CoordenationId é obrigatório");
            }
        }

        public static string ClassCourseVersionIdRequired
        {
            get
            {
                return Localize("CourseVersionId é obrigatório");
            }
        }

        public static string ClassDescriptionStringLength
        {
            get
            {
                return Localize("O campo Description aceita no máximo 255 caracteres.");
            }
        }
        
        public static string ClassLegacySystemIDStringLength
        {
            get
            {
                return Localize("O campo LegacySystemID aceita no máximo 100 caracteres.");
            }
        }
        
        public static string ClassLibraryPositionRequired
        {
            get
            {
                return Localize("LibraryPosition é obrigatório");
            }
        }

        public static string ClassNotifyTutorOnChangeRequired
        {
            get
            {
                return Localize("NotifyTutorOnChange é obrigatório");
            }
        }
        
        public static string ClassShowClassExternalCalendarRequired
        {
            get
            {
                return Localize("ShowClassExternalCalendar é obrigatório");
            }
        }

        public static string ClassShowClassInternalCalendarRequired
        {
            get
            {
                return Localize("ShowClassInternalCalendar é obrigatório");
            }
        }

        public static string ClassStartsOnRequired
        {
            get
            {
                return Localize("StartsOn é obrigatório");
            }
        }
        
        public static string ClassTaskDispatcherIdRequired
        {
            get
            {
                return Localize("TaskDispatcherID é obrigatório");
            }
        }

        public static string ClassTypeRequired
        {
            get
            {
                return Localize("Type é obrigatório");
            }
        }

        public static string ClassUserClassNameStringLength
        {
            get
            {
                return Localize("O campo UserClassName aceita no máximo 255 caracteres.");
            }
        }

        public static string ClassUserClassNameRequired
        {
            get
            {
                return Localize("UserClassName é obrigatório");
            }
        }

        public static string ClassAccessAccessIdRequired
        {
            get
            {
                return Localize("AccessId é obrigatório");
            }
        }
        
        public static string ClassAccessClassIdRequired
        {
            get
            {
                return Localize("ClassId é obrigatório");
            }
        }
        
        public static string ClassTutorClassIdRequired
        {
            get
            {
                return Localize("ClassId é obrigatório");
            }
        }
        
        public static string ClassTutorTutorIdRequired
        {
            get
            {
                return Localize("TutorId é obrigatório");
            }
        }
        
        public static string ClassAvailabilityClassIdRequired
        {
            get
            {
                return Localize("ClassId é obrigatório");
            }
        }

        public static string ClassAvailabilityFinishesOnRequired
        {
            get
            {
                return Localize("FinishesOn é obrigatório");
            }
        }

        public static string ClassAvailabilityStartsOnRequired
        {
            get
            {
                return Localize("StartsOn é obrigatório");
            }
        }

        public static string ClassAvailabilityWeekDaysRequired
        {
            get
            {
                return Localize("WeekDays é obrigatório");
            }
        }

        public static string ClassResourcesCostAchievedCostRequired
        {
            get
            {
                return Localize("AchievedCost é obrigatório");
            }
        }

        public static string ClassResourcesCostAchievedVolumeRequired
        {
            get
            {
                return Localize("AchievedVolume é obrigatório");
            }
        }
        
        public static string ClassResourcesCostClassroomResourcesIdRequired
        {
            get
            {
                return Localize("ClassroomResourcesId é obrigatório");
            }
        }

        public static string ClassResourcesCostEstimatedCostRequired
        {
            get
            {
                return Localize("EstimatedCost é obrigatório");
            }
        }

        public static string ClassResourcesCostEstimatedVolumeRequired
        {
            get
            {
                return Localize("EstimatedVolume é obrigatório");
            }
        }

        public static string ClassroomCapacityRequired
        {
            get
            {
                return Localize("Capacity é obrigatório");
            }
        }
        
        public static string ClassroomContactIdRequired
        {
            get
            {
                return Localize("ContactID é obrigatório");
            }
        }

        public static string ClassroomNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 255 caracteres.");
            }
        }

        public static string ClassroomNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }

        public static string ClassroomSiteStringLength
        {
            get
            {
                return Localize("O campo Site aceita no máximo 255 caracteres.");
            }
        }
        
        public static string ClassroomClassroomResourcesClassroomIdRequired
        {
            get
            {
                return Localize("ClassroomId é obrigatório");
            }
        }
        
        public static string ClassroomClassroomResourcesClassroomResourcesIdRequired
        {
            get
            {
                return Localize("ClassroomResourcesId é obrigatório");
            }
        }
        
        public static string ClassroomResourcesBatchSetupIdRequired
        {
            get
            {
                return Localize("BatchSetupID é obrigatório");
            }
        }
        
        public static string ClassroomResourcesClassroomResourcesCategoryIdRequired
        {
            get
            {
                return Localize("ClassroomResourcesCategoryID é obrigatório");
            }
        }
        
        public static string ClassroomResourcesControlAllocationRequired
        {
            get
            {
                return Localize("ControlAllocation é obrigatório");
            }
        }

        public static string ClassroomResourcesCostRequired
        {
            get
            {
                return Localize("Cost é obrigatório");
            }
        }

        public static string ClassroomResourcesNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 255 caracteres.");
            }
        }

        public static string ClassroomResourcesNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }
        
        public static string ClassroomResourcesServiceIdRequired
        {
            get
            {
                return Localize("ServiceID é obrigatório");
            }
        }
        
        public static string ClassroomResourcesCategoryNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 255 caracteres.");
            }
        }

        public static string ClassroomResourcesCategoryNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }

        public static string ClassTutorCostAchievedCostRequired
        {
            get
            {
                return Localize("AchievedCost é obrigatório");
            }
        }
        
        public static string ClassTutorCostEstimatedCostRequired
        {
            get
            {
                return Localize("EstimatedCost é obrigatório");
            }
        }

        public static string ClassTutorCostFinalCostRequired
        {
            get
            {
                return Localize("FinalCost é obrigatório");
            }
        }

        public static string ClassTutorCostLocalLessonIdRequired
        {
            get
            {
                return Localize("LocalLessonId é obrigatório");
            }
        }

        public static string ClassTutorCostTutorIdRequired
        {
            get
            {
                return Localize("TutorId é obrigatório");
            }
        }

        public static string ClassTutorCostTutorRoleRequired
        {
            get
            {
                return Localize("TutorRole é obrigatório");
            }
        }

        public static string ClosedQuestionAssessmentQuestionIdRequired
        {
            get
            {
                return Localize("AssessmentQuestionId é obrigatório");
            }
        }
        
        public static string ClosedQuestionNumberOfItensRequired
        {
            get
            {
                return Localize("NumberOfItens é obrigatório");
            }
        }

        public static string ClosedQuestionRondomizeRequired
        {
            get
            {
                return Localize("Rondomize é obrigatório");
            }
        }

        public static string ClosedQuestionTypeRequired
        {
            get
            {
                return Localize("Type é obrigatório");
            }
        }

        public static string CommunityCommunityCategoryIdRequired
        {
            get
            {
                return Localize("CommunityCategoryId é obrigatório");
            }
        }
        
        public static string CommunityCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string CommunityCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }

        public static string CommunityDescriptionStringLength
        {
            get
            {
                return Localize("O campo Description aceita no máximo 500 caracteres.");
            }
        }

        public static string CommunityImagePathStringLength
        {
            get
            {
                return Localize("O campo ImagePath aceita no máximo 255 caracteres.");
            }
        }
        
        public static string CommunityIsPublicRequired
        {
            get
            {
                return Localize("IsPublic é obrigatório");
            }
        }

        public static string CommunityNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 50 caracteres.");
            }
        }

        public static string CommunityNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }

        public static string CommunityStartsOnRequired
        {
            get
            {
                return Localize("StartsOn é obrigatório");
            }
        }

        public static string CommunityTotalAccessRequired
        {
            get
            {
                return Localize("TotalAccess é obrigatório");
            }
        }

        public static string CommunityClassClassIdRequired
        {
            get
            {
                return Localize("ClassId é obrigatório");
            }
        }
        
        public static string CommunityClassCommunityIdRequired
        {
            get
            {
                return Localize("CommunityId é obrigatório");
            }
        }
        
        public static string CommunityCourseCommunityIdRequired
        {
            get
            {
                return Localize("CommunityId é obrigatório");
            }
        }
        
        public static string CommunityCourseCourseIdRequired
        {
            get
            {
                return Localize("CourseId é obrigatório");
            }
        }
        
        public static string CommunityTagCommunityIdRequired
        {
            get
            {
                return Localize("CommunityId é obrigatório");
            }
        }
        
        public static string CommunityTagTagIdRequired
        {
            get
            {
                return Localize("TagId é obrigatório");
            }
        }
        
        public static string CommunityUnitCommunityIdRequired
        {
            get
            {
                return Localize("CommunityId é obrigatório");
            }
        }
        
        public static string CommunityUnitUnitIdRequired
        {
            get
            {
                return Localize("UnitId é obrigatório");
            }
        }
        
        public static string CommunityCategoryCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }

        public static string CommunityCategoryNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 50 caracteres.");
            }
        }

        public static string CommunityCategoryNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }
        
        public static string CommunityCommentCommunityIdRequired
        {
            get
            {
                return Localize("CommunityId é obrigatório");
            }
        }

        public static string CommunityCommentCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string CommunityCommentCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }

        public static string CommunityCommentIsApprovedRequired
        {
            get
            {
                return Localize("IsApproved é obrigatório");
            }
        }

        public static string CommunityCommentTextStringLength
        {
            get
            {
                return Localize("O campo Text aceita no máximo 500 caracteres.");
            }
        }

        public static string CommunityCommentTextRequired
        {
            get
            {
                return Localize("Text é obrigatório");
            }
        }

        public static string CommunityPermissionCommunityIdRequired
        {
            get
            {
                return Localize("CommunityId é obrigatório");
            }
        }
        
        public static string CommunityPermissionCreatePrivateCommunityRequired
        {
            get
            {
                return Localize("CreatePrivateCommunity é obrigatório");
            }
        }

        public static string CommunityPermissionCreatePublicCommunityRequired
        {
            get
            {
                return Localize("CreatePublicCommunity é obrigatório");
            }
        }

        public static string CommunityPermissionIsModeratorRequired
        {
            get
            {
                return Localize("IsModerator é obrigatório");
            }
        }

        public static string CommunityPermissionUserIdRequired
        {
            get
            {
                return Localize("UserId é obrigatório");
            }
        }
        
        public static string ComponentCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string ComponentCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }

        public static string ComponentNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 50 caracteres.");
            }
        }

        public static string ComponentNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }

        public static string ConferenceEventAppointmentIdRequired
        {
            get
            {
                return Localize("AppointmentId é obrigatório");
            }
        }
        
        public static string ConferenceEventCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string ConferenceEventCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }

        public static string ConferenceEventDescriptionStringLength
        {
            get
            {
                return Localize("O campo Description aceita no máximo 500 caracteres.");
            }
        }
        
        public static string ConferenceEventDurationRequired
        {
            get
            {
                return Localize("Duration é obrigatório");
            }
        }

        public static string ConferenceEventFinishesOnRequired
        {
            get
            {
                return Localize("FinishesOn é obrigatório");
            }
        }

        public static string ConferenceEventNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 200 caracteres.");
            }
        }

        public static string ConferenceEventNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }

        public static string ConferenceEventPresentedByRequired
        {
            get
            {
                return Localize("PresentedBy é obrigatório");
            }
        }

        public static string ConferenceEventStartsOnRequired
        {
            get
            {
                return Localize("StartsOn é obrigatório");
            }
        }

        public static string ConferenceEventClassClassIdRequired
        {
            get
            {
                return Localize("ClassId é obrigatório");
            }
        }
        
        public static string ConferenceEventClassConferenceEventIdRequired
        {
            get
            {
                return Localize("ConferenceEventId é obrigatório");
            }
        }
        
        public static string ConferenceEventCommunityCommunityIdRequired
        {
            get
            {
                return Localize("CommunityId é obrigatório");
            }
        }
        
        public static string ConferenceEventCommunityConferenceEventIdRequired
        {
            get
            {
                return Localize("ConferenceEventId é obrigatório");
            }
        }
        
        public static string ConferenceEventUserConferenceEventIdRequired
        {
            get
            {
                return Localize("ConferenceEventId é obrigatório");
            }
        }
        
        public static string ConferenceEventUserUserIdRequired
        {
            get
            {
                return Localize("UserId é obrigatório");
            }
        }
        
        public static string ContactCellPhoneStringLength
        {
            get
            {
                return Localize("O campo CellPhone aceita no máximo 19 caracteres.");
            }
        }
        
        public static string ContactCepStringLength
        {
            get
            {
                return Localize("O campo Cep aceita no máximo 10 caracteres.");
            }
        }
        
        public static string ContactCityIdRequired
        {
            get
            {
                return Localize("CityId é obrigatório");
            }
        }

        public static string ContactComplementStringLength
        {
            get
            {
                return Localize("O campo Complement aceita no máximo 50 caracteres.");
            }
        }

        public static string ContactCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string ContactCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }

        public static string ContactEmailStringLength
        {
            get
            {
                return Localize("O campo Email aceita no máximo 100 caracteres.");
            }
        }

        public static string ContactEmailRequired
        {
            get
            {
                return Localize("Email é obrigatório");
            }
        }

        public static string ContactFaxStringLength
        {
            get
            {
                return Localize("O campo Fax aceita no máximo 19 caracteres.");
            }
        }
        
        public static string ContactIsMainContactRequired
        {
            get
            {
                return Localize("IsMainContact é obrigatório");
            }
        }

        public static string ContactMembershipUserIdRequired
        {
            get
            {
                return Localize("MembershipUserId é obrigatório");
            }
        }

        public static string ContactNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 100 caracteres.");
            }
        }

        public static string ContactNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }

        public static string ContactNeighborhoodStringLength
        {
            get
            {
                return Localize("O campo Neighborhood aceita no máximo 50 caracteres.");
            }
        }

        public static string ContactNumberRequired
        {
            get
            {
                return Localize("Number é obrigatório");
            }
        }

        public static string ContactPhoneStringLength
        {
            get
            {
                return Localize("O campo Phone aceita no máximo 19 caracteres.");
            }
        }
        
        public static string ContactSignatureStringLength
        {
            get
            {
                return Localize("O campo Signature aceita no máximo 200 caracteres.");
            }
        }
        
        public static string ContactStreetAddressStringLength
        {
            get
            {
                return Localize("O campo StreetAddress aceita no máximo 50 caracteres.");
            }
        }

        public static string ContactTypeRequired
        {
            get
            {
                return Localize("Type é obrigatório");
            }
        }

        public static string ContactServiceProviderContactIdRequired
        {
            get
            {
                return Localize("ContactId é obrigatório");
            }
        }
        
        public static string ContactServiceProviderServiceProviderIdRequired
        {
            get
            {
                return Localize("ServiceProviderId é obrigatório");
            }
        }
        
        public static string CoordenationNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 255 caracteres.");
            }
        }

        public static string CoordenationNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }
        
        public static string CountryNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 50 caracteres.");
            }
        }

        public static string CountryNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }

        public static string CourseAICCCompliantRequired
        {
            get
            {
                return Localize("AICCCompliant é obrigatório");
            }
        }

        public static string CourseAllowDemonstrationRequired
        {
            get
            {
                return Localize("AllowDemonstration é obrigatório");
            }
        }

        public static string CourseAllowPreRegistrationRequired
        {
            get
            {
                return Localize("AllowPreRegistration é obrigatório");
            }
        }

        public static string CourseApprovalScoreRequired
        {
            get
            {
                return Localize("ApprovalScore é obrigatório");
            }
        }

        public static string CourseCourseGroupIdRequired
        {
            get
            {
                return Localize("CourseGroupId é obrigatório");
            }
        }
        
        public static string CourseIPRangeIdRequired
        {
            get
            {
                return Localize("IPRangeId é obrigatório");
            }
        }

        public static string CourseIsActiveRequired
        {
            get
            {
                return Localize("IsActive é obrigatório");
            }
        }

        public static string CourseIsHighlightRequired
        {
            get
            {
                return Localize("IsHighlight é obrigatório");
            }
        }

        public static string CourseIsLocalRequired
        {
            get
            {
                return Localize("IsLocal é obrigatório");
            }
        }

        public static string CourseIsOnLineRequired
        {
            get
            {
                return Localize("IsOnLine é obrigatório");
            }
        }

        public static string CourseLegacySystemIDStringLength
        {
            get
            {
                return Localize("O campo LegacySystemID aceita no máximo 100 caracteres.");
            }
        }
        
        public static string CourseMinimumFrequencyRequired
        {
            get
            {
                return Localize("MinimumFrequency é obrigatório");
            }
        }

        public static string CourseNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 255 caracteres.");
            }
        }

        public static string CourseNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }

        public static string CoursePhysicalPathStringLength
        {
            get
            {
                return Localize("O campo PhysicalPath aceita no máximo 255 caracteres.");
            }
        }

        public static string CoursePhysicalPathRequired
        {
            get
            {
                return Localize("PhysicalPath é obrigatório");
            }
        }

        public static string CoursePopupCourseRequired
        {
            get
            {
                return Localize("PopupCourse é obrigatório");
            }
        }

        public static string CoursePositionRequired
        {
            get
            {
                return Localize("Position é obrigatório");
            }
        }
        
        public static string CoursePrerequisiteIdRequired
        {
            get
            {
                return Localize("PrerequisiteID é obrigatório");
            }
        }

        public static string CourseScormCompliantRequired
        {
            get
            {
                return Localize("ScormCompliant é obrigatório");
            }
        }

        public static string CourseShowOnCatalogRequired
        {
            get
            {
                return Localize("ShowOnCatalog é obrigatório");
            }
        }

        public static string CourseShowTutorPaymentRequired
        {
            get
            {
                return Localize("ShowTutorPayment é obrigatório");
            }
        }

        public static string CourseStudentCourseNameStringLength
        {
            get
            {
                return Localize("O campo StudentCourseName aceita no máximo 255 caracteres.");
            }
        }

        public static string CourseStudentCourseNameRequired
        {
            get
            {
                return Localize("StudentCourseName é obrigatório");
            }
        }
        
        public static string CourseFeaturesNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 100 caracteres.");
            }
        }

        public static string CourseFeaturesNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }

        public static string CourseFeaturesPositionRequired
        {
            get
            {
                return Localize("Position é obrigatório");
            }
        }

        public static string CourseFeaturesResumeCourseCourseFeaturesIdRequired
        {
            get
            {
                return Localize("CourseFeaturesId é obrigatório");
            }
        }
        
        public static string CourseFeaturesResumeCourseResumeCourseIdRequired
        {
            get
            {
                return Localize("ResumeCourseId é obrigatório");
            }
        }
        
        public static string CourseGroupCourseGroupParentIdRequired
        {
            get
            {
                return Localize("CourseGroupParentID é obrigatório");
            }
        }

        public static string CourseGroupIsHighlightRequired
        {
            get
            {
                return Localize("IsHighlight é obrigatório");
            }
        }

        public static string CourseGroupNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 255 caracteres.");
            }
        }

        public static string CourseGroupNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }

        public static string CourseGroupTrainingNameStringLength
        {
            get
            {
                return Localize("O campo TrainingName aceita no máximo 255 caracteres.");
            }
        }

        public static string CourseGroupTrainingNameRequired
        {
            get
            {
                return Localize("TrainingName é obrigatório");
            }
        }

        public static string CourseVersionCourseIdRequired
        {
            get
            {
                return Localize("CourseId é obrigatório");
            }
        }
        
        public static string CourseVersionCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string CourseVersionCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }

        public static string CourseVersionVersionRequired
        {
            get
            {
                return Localize("Version é obrigatório");
            }
        }

        public static string DaysOfWeekDayStringLength
        {
            get
            {
                return Localize("O campo Day aceita no máximo 30 caracteres.");
            }
        }

        public static string DaysOfWeekDayRequired
        {
            get
            {
                return Localize("Day é obrigatório");
            }
        }
        
        public static string DifficultyLevelNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 255 caracteres.");
            }
        }

        public static string DifficultyLevelNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }

        public static string EducationLevelCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string EducationLevelCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }
        
        public static string EducationLevelLevelStringLength
        {
            get
            {
                return Localize("O campo Level aceita no máximo 50 caracteres.");
            }
        }

        public static string EducationLevelLevelRequired
        {
            get
            {
                return Localize("Level é obrigatório");
            }
        }

        public static string EmailQueueAttemptsRequired
        {
            get
            {
                return Localize("Attempts é obrigatório");
            }
        }
        
        public static string EmailQueueEmailXmlStringLength
        {
            get
            {
                return Localize("O campo EmailXml aceita no máximo -1 caracteres.");
            }
        }

        public static string EmailQueueEmailXmlRequired
        {
            get
            {
                return Localize("EmailXml é obrigatório");
            }
        }

        public static string EmailQueueNextAttemptDateRequired
        {
            get
            {
                return Localize("NextAttemptDate é obrigatório");
            }
        }

        public static string EmailTemplateBodyStringLength
        {
            get
            {
                return Localize("O campo Body aceita no máximo -1 caracteres.");
            }
        }

        public static string EmailTemplateBodyRequired
        {
            get
            {
                return Localize("Body é obrigatório");
            }
        }
        
        public static string EmailTemplateIsHtmlRequired
        {
            get
            {
                return Localize("IsHtml é obrigatório");
            }
        }

        public static string EmailTemplateSubjectStringLength
        {
            get
            {
                return Localize("O campo Subject aceita no máximo 200 caracteres.");
            }
        }

        public static string EmailTemplateSubjectRequired
        {
            get
            {
                return Localize("Subject é obrigatório");
            }
        }

        public static string EssayAttemptsAnswerContentStringLength
        {
            get
            {
                return Localize("O campo AnswerContent aceita no máximo -1 caracteres.");
            }
        }

        public static string EssayAttemptsAnswerContentRequired
        {
            get
            {
                return Localize("AnswerContent é obrigatório");
            }
        }
        
        public static string EssayAttemptsQuestionAttemptsIdRequired
        {
            get
            {
                return Localize("QuestionAttemptsId é obrigatório");
            }
        }

        public static string EssayQuestionAssessmentQuestionIdRequired
        {
            get
            {
                return Localize("AssessmentQuestionId é obrigatório");
            }
        }

        public static string EssayQuestionContentStringLength
        {
            get
            {
                return Localize("O campo Content aceita no máximo 255 caracteres.");
            }
        }

        public static string EssayQuestionContentRequired
        {
            get
            {
                return Localize("Content é obrigatório");
            }
        }
        
        public static string ExpressionCommentStringLength
        {
            get
            {
                return Localize("O campo Comment aceita no máximo 255 caracteres.");
            }
        }
        
        public static string ExpressionCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }

        public static string ExpressionCultureStringLength
        {
            get
            {
                return Localize("O campo Culture aceita no máximo 14 caracteres.");
            }
        }

        public static string ExpressionCultureRequired
        {
            get
            {
                return Localize("Culture é obrigatório");
            }
        }
        
        public static string ExpressionNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 100 caracteres.");
            }
        }

        public static string ExpressionNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }

        public static string ExpressionTextStringLength
        {
            get
            {
                return Localize("O campo Text aceita no máximo 255 caracteres.");
            }
        }

        public static string ExpressionTextRequired
        {
            get
            {
                return Localize("Text é obrigatório");
            }
        }
        
        public static string FeedbackIsMandatoryRequired
        {
            get
            {
                return Localize("IsMandatory é obrigatório");
            }
        }

        public static string FeedbackLearningObjectIdRequired
        {
            get
            {
                return Localize("LearningObjectId é obrigatório");
            }
        }
        
        public static string FeedbackCategoryNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 255 caracteres.");
            }
        }

        public static string FeedbackCategoryNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }
        
        public static string FeedbackItemFeedbackQuestionIdRequired
        {
            get
            {
                return Localize("FeedbackQuestionId é obrigatório");
            }
        }

        public static string FeedbackItemNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 255 caracteres.");
            }
        }

        public static string FeedbackItemNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }

        public static string FeedbackItemPostionRequired
        {
            get
            {
                return Localize("Postion é obrigatório");
            }
        }

        public static string FeedbackQuestionAllowJustificationRequired
        {
            get
            {
                return Localize("AllowJustification é obrigatório");
            }
        }

        public static string FeedbackQuestionFeedbackCategoryIdRequired
        {
            get
            {
                return Localize("FeedbackCategoryId é obrigatório");
            }
        }

        public static string FeedbackQuestionFeedbackIdRequired
        {
            get
            {
                return Localize("FeedbackId é obrigatório");
            }
        }
        
        public static string FeedbackQuestionIsActiveRequired
        {
            get
            {
                return Localize("IsActive é obrigatório");
            }
        }

        public static string FeedbackQuestionIsJustificationMandatoryRequired
        {
            get
            {
                return Localize("IsJustificationMandatory é obrigatório");
            }
        }

        public static string FeedbackQuestionPostionRequired
        {
            get
            {
                return Localize("Postion é obrigatório");
            }
        }

        public static string FeedbackQuestionTextStringLength
        {
            get
            {
                return Localize("O campo Text aceita no máximo 255 caracteres.");
            }
        }

        public static string FeedbackQuestionTextRequired
        {
            get
            {
                return Localize("Text é obrigatório");
            }
        }

        public static string ForumCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string ForumCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }

        public static string ForumDescriptionStringLength
        {
            get
            {
                return Localize("O campo Description aceita no máximo 500 caracteres.");
            }
        }

        public static string ForumIsActiveRequired
        {
            get
            {
                return Localize("IsActive é obrigatório");
            }
        }

        public static string ForumLearningObjectIdRequired
        {
            get
            {
                return Localize("LearningObjectId é obrigatório");
            }
        }

        public static string ForumModeratedByRequired
        {
            get
            {
                return Localize("ModeratedBy é obrigatório");
            }
        }

        public static string ForumNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 50 caracteres.");
            }
        }

        public static string ForumNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }

        public static string ForumTypeRequired
        {
            get
            {
                return Localize("Type é obrigatório");
            }
        }

        public static string ForumClassClassIdRequired
        {
            get
            {
                return Localize("ClassId é obrigatório");
            }
        }
        
        public static string ForumClassForumIdRequired
        {
            get
            {
                return Localize("ForumId é obrigatório");
            }
        }
        
        public static string ForumCommunityCommunityIdRequired
        {
            get
            {
                return Localize("CommunityId é obrigatório");
            }
        }
        
        public static string ForumCommunityForumIdRequired
        {
            get
            {
                return Localize("ForumId é obrigatório");
            }
        }
        
        public static string ForumCourseCourseIdRequired
        {
            get
            {
                return Localize("CourseId é obrigatório");
            }
        }
        
        public static string ForumCourseForumIdRequired
        {
            get
            {
                return Localize("ForumId é obrigatório");
            }
        }
        
        public static string ForumPostAllowAnswerRequired
        {
            get
            {
                return Localize("AllowAnswer é obrigatório");
            }
        }

        public static string ForumPostCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string ForumPostCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }

        public static string ForumPostDescriptionStringLength
        {
            get
            {
                return Localize("O campo Description aceita no máximo 500 caracteres.");
            }
        }

        public static string ForumPostForumTopicIdRequired
        {
            get
            {
                return Localize("ForumTopicId é obrigatório");
            }
        }

        public static string ForumPostMediaIdRequired
        {
            get
            {
                return Localize("MediaId é obrigatório");
            }
        }
        
        public static string ForumPostTitleStringLength
        {
            get
            {
                return Localize("O campo Title aceita no máximo 50 caracteres.");
            }
        }

        public static string ForumPostTitleRequired
        {
            get
            {
                return Localize("Title é obrigatório");
            }
        }

        public static string ForumTopicAllowAnwserRequired
        {
            get
            {
                return Localize("AllowAnwser é obrigatório");
            }
        }

        public static string ForumTopicCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string ForumTopicCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }

        public static string ForumTopicDescriptionStringLength
        {
            get
            {
                return Localize("O campo Description aceita no máximo 500 caracteres.");
            }
        }
        
        public static string ForumTopicForumIdRequired
        {
            get
            {
                return Localize("ForumId é obrigatório");
            }
        }
        
        public static string ForumTopicIsScoringRequired
        {
            get
            {
                return Localize("IsScoring é obrigatório");
            }
        }

        public static string ForumTopicMediaIdRequired
        {
            get
            {
                return Localize("MediaId é obrigatório");
            }
        }

        public static string ForumTopicTitleStringLength
        {
            get
            {
                return Localize("O campo Title aceita no máximo 50 caracteres.");
            }
        }

        public static string ForumTopicTitleRequired
        {
            get
            {
                return Localize("Title é obrigatório");
            }
        }

        public static string GlossaryCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }

        public static string GlossaryDescriptionStringLength
        {
            get
            {
                return Localize("O campo Description aceita no máximo 500 caracteres.");
            }
        }

        public static string GlossaryDescriptionRequired
        {
            get
            {
                return Localize("Description é obrigatório");
            }
        }
        
        public static string GlossaryKeywordStringLength
        {
            get
            {
                return Localize("O campo Keyword aceita no máximo 50 caracteres.");
            }
        }

        public static string GlossaryKeywordRequired
        {
            get
            {
                return Localize("Keyword é obrigatório");
            }
        }
        
        public static string InstantiatedLearningObjectsClassIdRequired
        {
            get
            {
                return Localize("ClassID é obrigatório");
            }
        }

        public static string InstantiatedLearningObjectsCourseVersionIdRequired
        {
            get
            {
                return Localize("CourseVersionId é obrigatório");
            }
        }
        
        public static string InstantiatedLearningObjectsLearningObjectIdRequired
        {
            get
            {
                return Localize("LearningObjectId é obrigatório");
            }
        }

        public static string InstantiatedLearningObjectsPrerequisiteIdRequired
        {
            get
            {
                return Localize("PrerequisiteId é obrigatório");
            }
        }

        public static string InstantiatedLearningObjectsTrainingRealizationIdRequired
        {
            get
            {
                return Localize("TrainingRealizationId é obrigatório");
            }
        }

        public static string IPRangeFinishesOnStringLength
        {
            get
            {
                return Localize("O campo FinishesOn aceita no máximo 15 caracteres.");
            }
        }

        public static string IPRangeStartsOnStringLength
        {
            get
            {
                return Localize("O campo StartsOn aceita no máximo 15 caracteres.");
            }
        }

        public static string IPRangeStartsOnRequired
        {
            get
            {
                return Localize("StartsOn é obrigatório");
            }
        }

        public static string JobTitleCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string JobTitleCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }

        public static string JobTitleIsActiveRequired
        {
            get
            {
                return Localize("IsActive é obrigatório");
            }
        }
        
        public static string JobTitleJobTitleParentIdRequired
        {
            get
            {
                return Localize("JobTitleParentID é obrigatório");
            }
        }

        public static string JobTitleLegacySystemIdStringLength
        {
            get
            {
                return Localize("O campo LegacySystemID aceita no máximo 100 caracteres.");
            }
        }
        
        public static string JobTitleNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 50 caracteres.");
            }
        }

        public static string JobTitleNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }

        public static string LearningObjectFinishesOnRequired
        {
            get
            {
                return Localize("FinishesOn é obrigatório");
            }
        }
        
        public static string LearningObjectLearningObjectParentIdRequired
        {
            get
            {
                return Localize("LearningObjectParentID é obrigatório");
            }
        }

        public static string LearningObjectNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 255 caracteres.");
            }
        }

        public static string LearningObjectNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }

        public static string LearningObjectPositionRequired
        {
            get
            {
                return Localize("Position é obrigatório");
            }
        }

        public static string LearningObjectStartsOnRequired
        {
            get
            {
                return Localize("StartsOn é obrigatório");
            }
        }

        public static string LearningObjectTypeRequired
        {
            get
            {
                return Localize("Type é obrigatório");
            }
        }

        public static string LearningObjectUsedOnFrequencyRequired
        {
            get
            {
                return Localize("UsedOnFrequency é obrigatório");
            }
        }

        public static string LocalAssessmentAssessmentIdRequired
        {
            get
            {
                return Localize("AssessmentId é obrigatório");
            }
        }

        public static string LocalAssessmentClassroomIdRequired
        {
            get
            {
                return Localize("ClassroomId é obrigatório");
            }
        }
        
        public static string LocalAssessmentPayForLessonRequired
        {
            get
            {
                return Localize("PayForLesson é obrigatório");
            }
        }

        public static string LocalClassroomClassIdRequired
        {
            get
            {
                return Localize("ClassId é obrigatório");
            }
        }

        public static string LocalClassroomClassroomIdRequired
        {
            get
            {
                return Localize("ClassroomId é obrigatório");
            }
        }
        
        public static string LocalLessonApprovalScoreRequired
        {
            get
            {
                return Localize("ApprovalScore é obrigatório");
            }
        }

        public static string LocalLessonClassroomIdRequired
        {
            get
            {
                return Localize("ClassroomId é obrigatório");
            }
        }

        public static string LocalLessonDateRequired
        {
            get
            {
                return Localize("Date é obrigatório");
            }
        }

        public static string LocalLessonIsMandatoryRequired
        {
            get
            {
                return Localize("IsMandatory é obrigatório");
            }
        }

        public static string LocalLessonIsPaidRequired
        {
            get
            {
                return Localize("IsPaid é obrigatório");
            }
        }

        public static string LocalLessonIsUsedOnFinalScoreRequired
        {
            get
            {
                return Localize("IsUsedOnFinalScore é obrigatório");
            }
        }

        public static string LocalLessonLearningObjectIdRequired
        {
            get
            {
                return Localize("LearningObjectId é obrigatório");
            }
        }
        
        public static string LocalLessonNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 255 caracteres.");
            }
        }

        public static string LocalLessonNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }

        public static string LocalLessonPositionRequired
        {
            get
            {
                return Localize("Position é obrigatório");
            }
        }

        public static string LocalLessonProgrammaticContentStringLength
        {
            get
            {
                return Localize("O campo ProgrammaticContent aceita no máximo -1 caracteres.");
            }
        }
        
        public static string LocalLessonScoreRequired
        {
            get
            {
                return Localize("Score é obrigatório");
            }
        }

        public static string LocalLessonTutorIdRequired
        {
            get
            {
                return Localize("TutorId é obrigatório");
            }
        }

        public static string LocalLessonWorkloadRequired
        {
            get
            {
                return Localize("Workload é obrigatório");
            }
        }

        public static string MaritalStatusCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string MaritalStatusCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }
        
        public static string MaritalStatusStatusStringLength
        {
            get
            {
                return Localize("O campo Status aceita no máximo 50 caracteres.");
            }
        }

        public static string MaritalStatusStatusRequired
        {
            get
            {
                return Localize("Status é obrigatório");
            }
        }
        
        public static string MatchingItemMatchingQuestionItemIdRequired
        {
            get
            {
                return Localize("MatchingQuestionItemId é obrigatório");
            }
        }

        public static string MatchingItemMatchingTextStringLength
        {
            get
            {
                return Localize("O campo MatchingText aceita no máximo 255 caracteres.");
            }
        }

        public static string MatchingItemMatchingTextRequired
        {
            get
            {
                return Localize("MatchingText é obrigatório");
            }
        }

        public static string MatchingQuestionClosedQuestionIdRequired
        {
            get
            {
                return Localize("ClosedQuestionId é obrigatório");
            }
        }
        
        public static string MatchingQuestionRondomizeRequired
        {
            get
            {
                return Localize("Rondomize é obrigatório");
            }
        }

        public static string MatchingQuestionTotalAssociationsRequired
        {
            get
            {
                return Localize("TotalAssociations é obrigatório");
            }
        }

        public static string MatchingQuestionAttemptsMatchingItemIdRequired
        {
            get
            {
                return Localize("MatchingItemId é obrigatório");
            }
        }
        
        public static string MatchingQuestionAttemptsMatchingQuestionItemIdRequired
        {
            get
            {
                return Localize("MatchingQuestionItemId é obrigatório");
            }
        }

        public static string MatchingQuestionAttemptsQuestionAttemptsIdRequired
        {
            get
            {
                return Localize("QuestionAttemptsId é obrigatório");
            }
        }

        public static string MatchingQuestionItemMatchingQuestionIdRequired
        {
            get
            {
                return Localize("MatchingQuestionId é obrigatório");
            }
        }
        
        public static string MatchingQuestionItemTextStringLength
        {
            get
            {
                return Localize("O campo Text aceita no máximo 255 caracteres.");
            }
        }

        public static string MatchingQuestionItemTextRequired
        {
            get
            {
                return Localize("Text é obrigatório");
            }
        }
        
        public static string MediaApprovedByRequired
        {
            get
            {
                return Localize("ApprovedBy é obrigatório");
            }
        }
        
        public static string MediaBatchSetupIdRequired
        {
            get
            {
                return Localize("BatchSetupId é obrigatório");
            }
        }

        public static string MediaCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string MediaCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }

        public static string MediaImagePathStringLength
        {
            get
            {
                return Localize("O campo ImagePath aceita no máximo 255 caracteres.");
            }
        }
        
        public static string MediaMediaCategoryIdRequired
        {
            get
            {
                return Localize("MediaCategoryId é obrigatório");
            }
        }
        
        public static string MediaNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 50 caracteres.");
            }
        }

        public static string MediaNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }

        public static string MediaPathStringLength
        {
            get
            {
                return Localize("O campo Path aceita no máximo 255 caracteres.");
            }
        }
        
        public static string MediaRankingRequired
        {
            get
            {
                return Localize("Ranking é obrigatório");
            }
        }

        public static string MediaStatusRequired
        {
            get
            {
                return Localize("Status é obrigatório");
            }
        }

        public static string MediaTypeRequired
        {
            get
            {
                return Localize("Type é obrigatório");
            }
        }

        public static string MediaAreaAreaIdRequired
        {
            get
            {
                return Localize("AreaId é obrigatório");
            }
        }
        
        public static string MediaAreaMediaIdRequired
        {
            get
            {
                return Localize("MediaId é obrigatório");
            }
        }
        
        public static string MediaClassClassIdRequired
        {
            get
            {
                return Localize("ClassId é obrigatório");
            }
        }
        
        public static string MediaClassMediaIdRequired
        {
            get
            {
                return Localize("MediaId é obrigatório");
            }
        }
        
        public static string MediaCommunityCommunityIdRequired
        {
            get
            {
                return Localize("CommunityId é obrigatório");
            }
        }
        
        public static string MediaCommunityMediaIdRequired
        {
            get
            {
                return Localize("MediaId é obrigatório");
            }
        }
        
        public static string MediaCourseCourseIdRequired
        {
            get
            {
                return Localize("CourseId é obrigatório");
            }
        }
        
        public static string MediaCourseMediaIdRequired
        {
            get
            {
                return Localize("MediaId é obrigatório");
            }
        }
        
        public static string MediaProfileMediaIdRequired
        {
            get
            {
                return Localize("MediaId é obrigatório");
            }
        }
        
        public static string MediaProfileProfileIdRequired
        {
            get
            {
                return Localize("ProfileId é obrigatório");
            }
        }
        
        public static string MediaProgramMediaIdRequired
        {
            get
            {
                return Localize("MediaId é obrigatório");
            }
        }
        
        public static string MediaProgramProgramIdRequired
        {
            get
            {
                return Localize("ProgramId é obrigatório");
            }
        }
        
        public static string MediaTagMediaIdRequired
        {
            get
            {
                return Localize("MediaId é obrigatório");
            }
        }
        
        public static string MediaTagTagIdRequired
        {
            get
            {
                return Localize("TagId é obrigatório");
            }
        }
        
        public static string MediaUnitMediaIdRequired
        {
            get
            {
                return Localize("MediaId é obrigatório");
            }
        }
        
        public static string MediaUnitUnitIdRequired
        {
            get
            {
                return Localize("UnitId é obrigatório");
            }
        }
        
        public static string MediaAccessAccessedOnRequired
        {
            get
            {
                return Localize("AccessedOn é obrigatório");
            }
        }

        public static string MediaAccessCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }
        
        public static string MediaAccessMediaIdRequired
        {
            get
            {
                return Localize("MediaId é obrigatório");
            }
        }

        public static string MediaAccessRankIndexRequired
        {
            get
            {
                return Localize("RankIndex é obrigatório");
            }
        }

        public static string MediaCategoryCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string MediaCategoryCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }

        public static string MediaCategoryImageStringLength
        {
            get
            {
                return Localize("O campo Image aceita no máximo 255 caracteres.");
            }
        }

        public static string MediaCategoryImageRequired
        {
            get
            {
                return Localize("Image é obrigatório");
            }
        }
        
        public static string MediaCategoryNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 50 caracteres.");
            }
        }

        public static string MediaCategoryNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }

        public static string MediaDocumentContentStringLength
        {
            get
            {
                return Localize("O campo Content aceita no máximo -1 caracteres.");
            }
        }

        public static string MediaDocumentContentRequired
        {
            get
            {
                return Localize("Content é obrigatório");
            }
        }

        public static string MediaDocumentExtensionStringLength
        {
            get
            {
                return Localize("O campo Extension aceita no máximo 6 caracteres.");
            }
        }

        public static string MediaDocumentExtensionRequired
        {
            get
            {
                return Localize("Extension é obrigatório");
            }
        }

        public static string MediaDocumentFileNameStringLength
        {
            get
            {
                return Localize("O campo FileName aceita no máximo 50 caracteres.");
            }
        }

        public static string MediaDocumentFileNameRequired
        {
            get
            {
                return Localize("FileName é obrigatório");
            }
        }

        public static string MediaDocumentFilePathStringLength
        {
            get
            {
                return Localize("O campo FilePath aceita no máximo 255 caracteres.");
            }
        }

        public static string MediaDocumentFilePathRequired
        {
            get
            {
                return Localize("FilePath é obrigatório");
            }
        }
        
        public static string MediaDocumentMediaIdRequired
        {
            get
            {
                return Localize("MediaId é obrigatório");
            }
        }

        public static string MediaDocumentMimeTypeStringLength
        {
            get
            {
                return Localize("O campo MimeType aceita no máximo 50 caracteres.");
            }
        }

        public static string MediaDocumentMimeTypeRequired
        {
            get
            {
                return Localize("MimeType é obrigatório");
            }
        }

        public static string MediaDocumentSizeRequired
        {
            get
            {
                return Localize("Size é obrigatório");
            }
        }
        
        public static string MembershipUserCompanyStringLength
        {
            get
            {
                return Localize("O campo Company aceita no máximo 100 caracteres.");
            }
        }
        
        public static string MembershipUserCpfStringLength
        {
            get
            {
                return Localize("O campo Cpf aceita no máximo 11 caracteres.");
            }
        }
        
        public static string MembershipUserCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string MembershipUserCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }

        public static string MembershipUserDeletedByRequired
        {
            get
            {
                return Localize("DeletedBy é obrigatório");
            }
        }
        
        public static string MembershipUserEducationLevelIdRequired
        {
            get
            {
                return Localize("EducationLevelId é obrigatório");
            }
        }

        public static string MembershipUserEmailStringLength
        {
            get
            {
                return Localize("O campo Email aceita no máximo 255 caracteres.");
            }
        }

        public static string MembershipUserEmailRequired
        {
            get
            {
                return Localize("Email é obrigatório");
            }
        }

        public static string MembershipUserFailedAnswerAttemptCountRequired
        {
            get
            {
                return Localize("FailedAnswerAttemptCount é obrigatório");
            }
        }
        
        public static string MembershipUserFailedPasswordAttemptCountRequired
        {
            get
            {
                return Localize("FailedPasswordAttemptCount é obrigatório");
            }
        }
        
        public static string MembershipUserGenderRequired
        {
            get
            {
                return Localize("Gender é obrigatório");
            }
        }

        public static string MembershipUserImageStringLength
        {
            get
            {
                return Localize("O campo Image aceita no máximo 250 caracteres.");
            }
        }
        
        public static string MembershipUserIncomeRequired
        {
            get
            {
                return Localize("Income é obrigatório");
            }
        }

        public static string MembershipUserIsApprovedRequired
        {
            get
            {
                return Localize("IsApproved é obrigatório");
            }
        }

        public static string MembershipUserIsDeletedRequired
        {
            get
            {
                return Localize("IsDeleted é obrigatório");
            }
        }

        public static string MembershipUserIsLockedOutRequired
        {
            get
            {
                return Localize("IsLockedOut é obrigatório");
            }
        }

        public static string MembershipUserJobTitleIdRequired
        {
            get
            {
                return Localize("JobTitleId é obrigatório");
            }
        }
        
        public static string MembershipUserLegacySystemIdStringLength
        {
            get
            {
                return Localize("O campo LegacySystemID aceita no máximo 100 caracteres.");
            }
        }
        
        public static string MembershipUserMaritalStatusIdRequired
        {
            get
            {
                return Localize("MaritalStatusId é obrigatório");
            }
        }
        
        public static string MembershipUserNicknameStringLength
        {
            get
            {
                return Localize("O campo Nickname aceita no máximo 50 caracteres.");
            }
        }

        public static string MembershipUserNicknameRequired
        {
            get
            {
                return Localize("Nickname é obrigatório");
            }
        }

        public static string MembershipUserNotesStringLength
        {
            get
            {
                return Localize("O campo Notes aceita no máximo 255 caracteres.");
            }
        }
        
        public static string MembershipUserOccupationIdRequired
        {
            get
            {
                return Localize("OccupationId é obrigatório");
            }
        }

        public static string MembershipUserPasswordStringLength
        {
            get
            {
                return Localize("O campo Password aceita no máximo 100 caracteres.");
            }
        }

        public static string MembershipUserPasswordRequired
        {
            get
            {
                return Localize("Password é obrigatório");
            }
        }

        public static string MembershipUserPasswordFormatRequired
        {
            get
            {
                return Localize("PasswordFormat é obrigatório");
            }
        }

        public static string MembershipUserReceiveNewsletterRequired
        {
            get
            {
                return Localize("ReceiveNewsletter é obrigatório");
            }
        }

        public static string MembershipUserSectionIdRequired
        {
            get
            {
                return Localize("SectionId é obrigatório");
            }
        }

        public static string MembershipUserSecurityAnwserStringLength
        {
            get
            {
                return Localize("O campo SecurityAnwser aceita no máximo 100 caracteres.");
            }
        }

        public static string MembershipUserSecurityQuestionStringLength
        {
            get
            {
                return Localize("O campo SecurityQuestion aceita no máximo 100 caracteres.");
            }
        }
        
        public static string MembershipUserUserIdRequired
        {
            get
            {
                return Localize("UserId é obrigatório");
            }
        }
        
        public static string MentoringPlanBatchSetupIdRequired
        {
            get
            {
                return Localize("BatchSetupID é obrigatório");
            }
        }

        public static string MentoringPlanFinishesOnRequired
        {
            get
            {
                return Localize("FinishesOn é obrigatório");
            }
        }
        
        public static string MentoringPlanStartsOnRequired
        {
            get
            {
                return Localize("StartsOn é obrigatório");
            }
        }

        public static string MentoringPlanActivityActivityIdRequired
        {
            get
            {
                return Localize("ActivityId é obrigatório");
            }
        }

        public static string MentoringPlanActivityLearningObjectIdRequired
        {
            get
            {
                return Localize("LearningObjectId é obrigatório");
            }
        }
        
        public static string MentoringPlanActivityMentoringPlanIdRequired
        {
            get
            {
                return Localize("MentoringPlanId é obrigatório");
            }
        }

        public static string MentoringPlanActivityObservationStringLength
        {
            get
            {
                return Localize("O campo Observation aceita no máximo 255 caracteres.");
            }
        }
        
        public static string MenuImageStringLength
        {
            get
            {
                return Localize("O campo Image aceita no máximo 255 caracteres.");
            }
        }
        
        public static string MenuIndexStringLength
        {
            get
            {
                return Localize("O campo Index aceita no máximo 11 caracteres.");
            }
        }

        public static string MenuIndexRequired
        {
            get
            {
                return Localize("Index é obrigatório");
            }
        }
        
        public static string MenuNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 200 caracteres.");
            }
        }

        public static string MenuNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }

        public static string MenuPermissionIdRequired
        {
            get
            {
                return Localize("PermissionId é obrigatório");
            }
        }

        public static string MenuUrlStringLength
        {
            get
            {
                return Localize("O campo Url aceita no máximo 255 caracteres.");
            }
        }

        public static string MenuUrlRequired
        {
            get
            {
                return Localize("Url é obrigatório");
            }
        }

        public static string MessageAttachStringLength
        {
            get
            {
                return Localize("O campo Attach aceita no máximo 255 caracteres.");
            }
        }
        
        public static string MessageBodyStringLength
        {
            get
            {
                return Localize("O campo Body aceita no máximo 2147483647 caracteres.");
            }
        }

        public static string MessageBodyRequired
        {
            get
            {
                return Localize("Body é obrigatório");
            }
        }

        public static string MessageCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string MessageCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }

        public static string MessageIsAlertRequired
        {
            get
            {
                return Localize("IsAlert é obrigatório");
            }
        }

        public static string MessageIsDraftRequired
        {
            get
            {
                return Localize("IsDraft é obrigatório");
            }
        }

        public static string MessageIsReminderRequired
        {
            get
            {
                return Localize("IsReminder é obrigatório");
            }
        }

        public static string MessageMessageFolderIdRequired
        {
            get
            {
                return Localize("MessageFolderId é obrigatório");
            }
        }
        
        public static string MessageMessageParentIdRequired
        {
            get
            {
                return Localize("MessageParentID é obrigatório");
            }
        }

        public static string MessageSearchArgsStringLength
        {
            get
            {
                return Localize("O campo SearchArgs aceita no máximo 200 caracteres.");
            }
        }

        public static string MessageSearchArgsRequired
        {
            get
            {
                return Localize("SearchArgs é obrigatório");
            }
        }
        
        public static string MessageSubjectStringLength
        {
            get
            {
                return Localize("O campo Subject aceita no máximo 200 caracteres.");
            }
        }

        public static string MessageSubjectRequired
        {
            get
            {
                return Localize("Subject é obrigatório");
            }
        }

        public static string MessageFolderCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string MessageFolderCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }
        
        public static string MessageFolderMessageFolderParentIdRequired
        {
            get
            {
                return Localize("MessageFolderParentID é obrigatório");
            }
        }

        public static string MessageFolderNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 200 caracteres.");
            }
        }

        public static string MessageFolderNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }

        public static string ModuleCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string ModuleCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }
        
        public static string ModuleNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 50 caracteres.");
            }
        }

        public static string ModuleNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }

        public static string NewsContentStringLength
        {
            get
            {
                return Localize("O campo Content aceita no máximo -1 caracteres.");
            }
        }

        public static string NewsContentRequired
        {
            get
            {
                return Localize("Content é obrigatório");
            }
        }

        public static string NewsCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string NewsCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }
        
        public static string NewsImagePathStringLength
        {
            get
            {
                return Localize("O campo ImagePath aceita no máximo 255 caracteres.");
            }
        }
        
        public static string NewsIsActiveRequired
        {
            get
            {
                return Localize("IsActive é obrigatório");
            }
        }

        public static string NewsNewsCategoryIdRequired
        {
            get
            {
                return Localize("NewsCategoryId é obrigatório");
            }
        }
        
        public static string NewsSourceStringLength
        {
            get
            {
                return Localize("O campo Source aceita no máximo 255 caracteres.");
            }
        }
        
        public static string NewsStartsOnRequired
        {
            get
            {
                return Localize("StartsOn é obrigatório");
            }
        }

        public static string NewsSummaryStringLength
        {
            get
            {
                return Localize("O campo Summary aceita no máximo 500 caracteres.");
            }
        }
        
        public static string NewsTitleStringLength
        {
            get
            {
                return Localize("O campo Title aceita no máximo 255 caracteres.");
            }
        }

        public static string NewsTitleRequired
        {
            get
            {
                return Localize("Title é obrigatório");
            }
        }

        public static string NewsAreaAreaIdRequired
        {
            get
            {
                return Localize("AreaId é obrigatório");
            }
        }
        
        public static string NewsAreaNewsIdRequired
        {
            get
            {
                return Localize("NewsId é obrigatório");
            }
        }
        
        public static string NewsCommunityCommunityIdRequired
        {
            get
            {
                return Localize("CommunityId é obrigatório");
            }
        }
        
        public static string NewsCommunityNewsIdRequired
        {
            get
            {
                return Localize("NewsId é obrigatório");
            }
        }
        
        public static string NewsProfileNewsIdRequired
        {
            get
            {
                return Localize("NewsId é obrigatório");
            }
        }
        
        public static string NewsProfileProfileIdRequired
        {
            get
            {
                return Localize("ProfileId é obrigatório");
            }
        }
        
        public static string NewsUnitNewsIdRequired
        {
            get
            {
                return Localize("NewsId é obrigatório");
            }
        }
        
        public static string NewsUnitUnitIdRequired
        {
            get
            {
                return Localize("UnitId é obrigatório");
            }
        }
        
        public static string NewsCategoryNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 255 caracteres.");
            }
        }

        public static string NewsCategoryNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }
        
        public static string NewsletterBodyStringLength
        {
            get
            {
                return Localize("O campo Body aceita no máximo 2147483647 caracteres.");
            }
        }

        public static string NewsletterBodyRequired
        {
            get
            {
                return Localize("Body é obrigatório");
            }
        }

        public static string NewsletterCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string NewsletterCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }
        
        public static string NewsletterReceiveDeliveryNotificationRequired
        {
            get
            {
                return Localize("ReceiveDeliveryNotification é obrigatório");
            }
        }

        public static string NewsletterReceiveSentNotificationRequired
        {
            get
            {
                return Localize("ReceiveSentNotification é obrigatório");
            }
        }

        public static string NewsletterSearchArgsStringLength
        {
            get
            {
                return Localize("O campo SearchArgs aceita no máximo 200 caracteres.");
            }
        }

        public static string NewsletterSearchArgsRequired
        {
            get
            {
                return Localize("SearchArgs é obrigatório");
            }
        }
        
        public static string NewsletterSubjectStringLength
        {
            get
            {
                return Localize("O campo Subject aceita no máximo 200 caracteres.");
            }
        }

        public static string NewsletterSubjectRequired
        {
            get
            {
                return Localize("Subject é obrigatório");
            }
        }

        public static string NoteContentStringLength
        {
            get
            {
                return Localize("O campo Content aceita no máximo 500 caracteres.");
            }
        }

        public static string NoteContentRequired
        {
            get
            {
                return Localize("Content é obrigatório");
            }
        }

        public static string NoteCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }

        public static string NoteIsPublicRequired
        {
            get
            {
                return Localize("IsPublic é obrigatório");
            }
        }
        
        public static string NoteTrainingIdRequired
        {
            get
            {
                return Localize("TrainingId é obrigatório");
            }
        }

        public static string OccupationCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string OccupationCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }

        public static string OccupationNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 50 caracteres.");
            }
        }

        public static string OccupationNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }
        
        public static string OnlineAssessmentAccessPasswordStringLength
        {
            get
            {
                return Localize("O campo AccessPassword aceita no máximo 255 caracteres.");
            }
        }
        
        public static string OnlineAssessmentAllowUserToReviewRequired
        {
            get
            {
                return Localize("AllowUserToReview é obrigatório");
            }
        }

        public static string OnlineAssessmentAssessmentIdRequired
        {
            get
            {
                return Localize("AssessmentId é obrigatório");
            }
        }

        public static string OnlineAssessmentFinalTextStringLength
        {
            get
            {
                return Localize("O campo FinalText aceita no máximo 255 caracteres.");
            }
        }
        
        public static string OnlineAssessmentIPRangeIdRequired
        {
            get
            {
                return Localize("IPRangeId é obrigatório");
            }
        }

        public static string OnlineAssessmentMaxAttemptsRequired
        {
            get
            {
                return Localize("MaxAttempts é obrigatório");
            }
        }
        
        public static string OnlineAssessmentOpeningTextStringLength
        {
            get
            {
                return Localize("O campo OpeningText aceita no máximo 255 caracteres.");
            }
        }
        
        public static string OnlineAssessmentPasswordRequiredRequired
        {
            get
            {
                return Localize("PasswordRequired é obrigatório");
            }
        }

        public static string OnlineAssessmentShowAnswersOnFinishRequired
        {
            get
            {
                return Localize("ShowAnswersOnFinish é obrigatório");
            }
        }

        public static string OnlineAssessmentShowPerformanceRequired
        {
            get
            {
                return Localize("ShowPerformance é obrigatório");
            }
        }

        public static string OnlineAssessmentShowResourcesRequired
        {
            get
            {
                return Localize("ShowResources é obrigatório");
            }
        }

        public static string OnlineAssessmentShowScoreOnFinishRequired
        {
            get
            {
                return Localize("ShowScoreOnFinish é obrigatório");
            }
        }

        public static string OnlineAssessmentTimeLimitRequired
        {
            get
            {
                return Localize("TimeLimit é obrigatório");
            }
        }

        public static string OnlineClassClassIdRequired
        {
            get
            {
                return Localize("ClassId é obrigatório");
            }
        }

        public static string OnlineClassForceDeadlineStringLength
        {
            get
            {
                return Localize("O campo ForceDeadline aceita no máximo 18 caracteres.");
            }
        }
        
        public static string OnlineClassIsFreeRegistrationRequired
        {
            get
            {
                return Localize("IsFreeRegistration é obrigatório");
            }
        }
        
        public static string OnlineLessonApprovalScoreRequired
        {
            get
            {
                return Localize("ApprovalScore é obrigatório");
            }
        }

        public static string OnlineLessonDataFromLmsStringLength
        {
            get
            {
                return Localize("O campo DataFromLms aceita no máximo 500 caracteres.");
            }
        }
        
        public static string OnlineLessonDepthRequired
        {
            get
            {
                return Localize("Depth é obrigatório");
            }
        }

        public static string OnlineLessonIdentifierStringLength
        {
            get
            {
                return Localize("O campo Identifier aceita no máximo 255 caracteres.");
            }
        }

        public static string OnlineLessonIdentifierRequired
        {
            get
            {
                return Localize("Identifier é obrigatório");
            }
        }

        public static string OnlineLessonIsResourcesBlockedRequired
        {
            get
            {
                return Localize("IsResourcesBlocked é obrigatório");
            }
        }

        public static string OnlineLessonIsUsedOnFinalScoreRequired
        {
            get
            {
                return Localize("IsUsedOnFinalScore é obrigatório");
            }
        }

        public static string OnlineLessonIsVisibleRequired
        {
            get
            {
                return Localize("IsVisible é obrigatório");
            }
        }

        public static string OnlineLessonLearningObjectIdRequired
        {
            get
            {
                return Localize("LearningObjectId é obrigatório");
            }
        }
        
        public static string OnlineLessonMaxTimeAllowedRequired
        {
            get
            {
                return Localize("MaxTimeAllowed é obrigatório");
            }
        }
        
        public static string OnlineLessonParametersStringLength
        {
            get
            {
                return Localize("O campo Parameters aceita no máximo 500 caracteres.");
            }
        }

        public static string OnlineLessonParametersRequired
        {
            get
            {
                return Localize("Parameters é obrigatório");
            }
        }

        public static string OnlineLessonPRTypeStringLength
        {
            get
            {
                return Localize("O campo PRType aceita no máximo 255 caracteres.");
            }
        }

        public static string OnlineLessonPRTypeRequired
        {
            get
            {
                return Localize("PRType é obrigatório");
            }
        }

        public static string OnlineLessonPrerequisitesStringLength
        {
            get
            {
                return Localize("O campo Prerequisites aceita no máximo 255 caracteres.");
            }
        }

        public static string OnlineLessonPrerequisitesRequired
        {
            get
            {
                return Localize("Prerequisites é obrigatório");
            }
        }

        public static string OnlineLessonTimeLimitActionRequired
        {
            get
            {
                return Localize("TimeLimitAction é obrigatório");
            }
        }

        public static string OnlineLessonUrlStringLength
        {
            get
            {
                return Localize("O campo Url aceita no máximo 255 caracteres.");
            }
        }

        public static string OnlineLessonUrlRequired
        {
            get
            {
                return Localize("Url é obrigatório");
            }
        }

        public static string PermissionActionIdRequired
        {
            get
            {
                return Localize("ActionId é obrigatório");
            }
        }

        public static string PermissionComponentIdRequired
        {
            get
            {
                return Localize("ComponentId é obrigatório");
            }
        }

        public static string PermissionCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string PermissionCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }
        
        public static string PermissionModuleIdRequired
        {
            get
            {
                return Localize("ModuleID é obrigatório");
            }
        }
        
        public static string PermissionAccessIsAllowedRequired
        {
            get
            {
                return Localize("IsAllowed é obrigatório");
            }
        }
        
        public static string PermissionAccessPermissionIdRequired
        {
            get
            {
                return Localize("PermissionId é obrigatório");
            }
        }

        public static string PermissionAccessProfilePermissionAccessIdRequired
        {
            get
            {
                return Localize("PermissionAccessId é obrigatório");
            }
        }
        
        public static string PermissionAccessProfileProfileIdRequired
        {
            get
            {
                return Localize("ProfileId é obrigatório");
            }
        }
        
        public static string PermissionAccessUserPermissionAccessIdRequired
        {
            get
            {
                return Localize("PermissionAccessId é obrigatório");
            }
        }
        
        public static string PermissionAccessUserUserIdRequired
        {
            get
            {
                return Localize("UserId é obrigatório");
            }
        }
        
        public static string PrerequisiteIsApprovalRequired
        {
            get
            {
                return Localize("IsApproval é obrigatório");
            }
        }

        public static string PrerequisiteIsConclusionRequired
        {
            get
            {
                return Localize("IsConclusion é obrigatório");
            }
        }
        
        public static string PrerequisiteTypeRequired
        {
            get
            {
                return Localize("Type é obrigatório");
            }
        }

        public static string PrerequisiteCourseCourseIdRequired
        {
            get
            {
                return Localize("CourseId é obrigatório");
            }
        }
        
        public static string PrerequisiteCoursePrerequisiteIdRequired
        {
            get
            {
                return Localize("PrerequisiteId é obrigatório");
            }
        }

        public static string PrerequisiteGroupCourseIdRequired
        {
            get
            {
                return Localize("CourseId é obrigatório");
            }
        }
        
        public static string PrerequisiteGroupPrerequisiteGroupParentIdRequired
        {
            get
            {
                return Localize("PrerequisiteGroupParentID é obrigatório");
            }
        }

        public static string PrerequisiteGroupPrerequisiteIdRequired
        {
            get
            {
                return Localize("PrerequisiteId é obrigatório");
            }
        }

        public static string PrerequisiteILObjectsInstantiatedLearningObjectIdRequired
        {
            get
            {
                return Localize("InstantiatedLearningObjectId é obrigatório");
            }
        }

        public static string PrerequisiteILObjectsPrerequisiteIdRequired
        {
            get
            {
                return Localize("PrerequisiteId é obrigatório");
            }
        }
        
        public static string PrerequisiteProgramModulePrerequisiteIdRequired
        {
            get
            {
                return Localize("PrerequisiteId é obrigatório");
            }
        }
        
        public static string PrerequisiteProgramModuleProgramModuleIdRequired
        {
            get
            {
                return Localize("ProgramModuleId é obrigatório");
            }
        }

        public static string PrintedAssessmentClassNameStringLength
        {
            get
            {
                return Localize("O campo ClassName aceita no máximo 255 caracteres.");
            }
        }

        public static string PrintedAssessmentClassNameRequired
        {
            get
            {
                return Localize("ClassName é obrigatório");
            }
        }

        public static string PrintedAssessmentCourseNameStringLength
        {
            get
            {
                return Localize("O campo CourseName aceita no máximo 255 caracteres.");
            }
        }

        public static string PrintedAssessmentCourseNameRequired
        {
            get
            {
                return Localize("CourseName é obrigatório");
            }
        }

        public static string PrintedAssessmentCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string PrintedAssessmentFinalTextStringLength
        {
            get
            {
                return Localize("O campo FinalText aceita no máximo 255 caracteres.");
            }
        }
        
        public static string PrintedAssessmentHeaderStringLength
        {
            get
            {
                return Localize("O campo Header aceita no máximo 255 caracteres.");
            }
        }

        public static string PrintedAssessmentHeaderRequired
        {
            get
            {
                return Localize("Header é obrigatório");
            }
        }
        
        public static string PrintedAssessmentLogoPathStringLength
        {
            get
            {
                return Localize("O campo LogoPath aceita no máximo 255 caracteres.");
            }
        }
        
        public static string PrintedAssessmentOnlineAssessmentIdRequired
        {
            get
            {
                return Localize("OnlineAssessmentId é obrigatório");
            }
        }

        public static string PrintedAssessmentOpeningTextStringLength
        {
            get
            {
                return Localize("O campo OpeningText aceita no máximo 255 caracteres.");
            }
        }

        public static string PrintedAssessmentPrintedOnRequired
        {
            get
            {
                return Localize("PrintedOn é obrigatório");
            }
        }

        public static string PrintedAssessmentScoreRequired
        {
            get
            {
                return Localize("Score é obrigatório");
            }
        }

        public static string PrintedAssessmentTutorNameStringLength
        {
            get
            {
                return Localize("O campo TutorName aceita no máximo 255 caracteres.");
            }
        }

        public static string PrintedAssessmentTutorNameRequired
        {
            get
            {
                return Localize("TutorName é obrigatório");
            }
        }

        public static string PrintedAssessmentUserNameStringLength
        {
            get
            {
                return Localize("O campo UserName aceita no máximo 255 caracteres.");
            }
        }

        public static string PrintedAssessmentUserNameRequired
        {
            get
            {
                return Localize("UserName é obrigatório");
            }
        }

        public static string ProfileCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string ProfileCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }

        public static string ProfileNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 30 caracteres.");
            }
        }

        public static string ProfileNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }
        
        public static string ProfileProfilePropertyProfileIdRequired
        {
            get
            {
                return Localize("ProfileId é obrigatório");
            }
        }
        
        public static string ProfileProfilePropertyProfilePropertyIdRequired
        {
            get
            {
                return Localize("ProfilePropertyId é obrigatório");
            }
        }
        
        public static string ProfileUserProfileIdRequired
        {
            get
            {
                return Localize("ProfileId é obrigatório");
            }
        }
        
        public static string ProfileUserUserIdRequired
        {
            get
            {
                return Localize("UserId é obrigatório");
            }
        }
        
        public static string ProfilePropertyCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string ProfilePropertyCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }

        public static string ProfilePropertyDataTypeStringLength
        {
            get
            {
                return Localize("O campo DataType aceita no máximo 30 caracteres.");
            }
        }

        public static string ProfilePropertyDataTypeRequired
        {
            get
            {
                return Localize("DataType é obrigatório");
            }
        }

        public static string ProfilePropertyNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 50 caracteres.");
            }
        }

        public static string ProfilePropertyNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }
        
        public static string ProgramAllowPreRegistrationRequired
        {
            get
            {
                return Localize("AllowPreRegistration é obrigatório");
            }
        }

        public static string ProgramAvailableRequired
        {
            get
            {
                return Localize("Available é obrigatório");
            }
        }

        public static string ProgramCertificationMinimumClassFrequencyRequired
        {
            get
            {
                return Localize("CertificationMinimumClassFrequency é obrigatório");
            }
        }

        public static string ProgramCertificationMinimumScoreRequired
        {
            get
            {
                return Localize("CertificationMinimumScore é obrigatório");
            }
        }

        public static string ProgramCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string ProgramCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }

        public static string ProgramDescriptionStringLength
        {
            get
            {
                return Localize("O campo Description aceita no máximo 255 caracteres.");
            }
        }

        public static string ProgramDescriptionRequired
        {
            get
            {
                return Localize("Description é obrigatório");
            }
        }

        public static string ProgramNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 255 caracteres.");
            }
        }

        public static string ProgramNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }
        
        public static string ProgramUserIdRequired
        {
            get
            {
                return Localize("UserId é obrigatório");
            }
        }

        public static string ProgramMediaMediaIdRequired
        {
            get
            {
                return Localize("MediaId é obrigatório");
            }
        }
        
        public static string ProgramMediaProgramIdRequired
        {
            get
            {
                return Localize("ProgramId é obrigatório");
            }
        }
        
        public static string ProgramProgramModuleProgramIdRequired
        {
            get
            {
                return Localize("ProgramId é obrigatório");
            }
        }
        
        public static string ProgramProgramModuleProgramModuleIdRequired
        {
            get
            {
                return Localize("ProgramModuleId é obrigatório");
            }
        }
        
        public static string ProgramModuleCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string ProgramModuleCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }

        public static string ProgramModuleDescriptionStringLength
        {
            get
            {
                return Localize("O campo Description aceita no máximo 255 caracteres.");
            }
        }

        public static string ProgramModuleDescriptionRequired
        {
            get
            {
                return Localize("Description é obrigatório");
            }
        }

        public static string ProgramModuleModeRequired
        {
            get
            {
                return Localize("Mode é obrigatório");
            }
        }

        public static string ProgramModuleNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 255 caracteres.");
            }
        }

        public static string ProgramModuleNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }

        public static string ProgramModulePositionRequired
        {
            get
            {
                return Localize("Position é obrigatório");
            }
        }

        public static string ProgramModulePrerequisiteIdRequired
        {
            get
            {
                return Localize("PrerequisiteId é obrigatório");
            }
        }
        
        public static string PropertyListCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string PropertyListCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }

        public static string PropertyListNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 50 caracteres.");
            }
        }

        public static string PropertyListNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }
        
        public static string PropertyListProfilePropertyIdRequired
        {
            get
            {
                return Localize("ProfilePropertyID é obrigatório");
            }
        }
        
        public static string PropertyListValueStringLength
        {
            get
            {
                return Localize("O campo Value aceita no máximo 500 caracteres.");
            }
        }

        public static string PropertyListValueRequired
        {
            get
            {
                return Localize("Value é obrigatório");
            }
        }

        public static string PropertyLogCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string PropertyLogCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }

        public static string PropertyLogNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 50 caracteres.");
            }
        }

        public static string PropertyLogNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }

        public static string PropertyLogOldValueStringLength
        {
            get
            {
                return Localize("O campo OldValue aceita no máximo 500 caracteres.");
            }
        }

        public static string PropertyLogValueStringLength
        {
            get
            {
                return Localize("O campo Value aceita no máximo 500 caracteres.");
            }
        }

        public static string PropertyLogValueRequired
        {
            get
            {
                return Localize("Value é obrigatório");
            }
        }

        public static string QuestionAttemptsAssessmentAttemptsIdRequired
        {
            get
            {
                return Localize("AssessmentAttemptsId é obrigatório");
            }
        }

        public static string QuestionAttemptsAssessmentQuestionIdRequired
        {
            get
            {
                return Localize("AssessmentQuestionId é obrigatório");
            }
        }
        
        public static string QuestionAttemptsScoreRequired
        {
            get
            {
                return Localize("Score é obrigatório");
            }
        }

        public static string QuestionCategoryNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 255 caracteres.");
            }
        }

        public static string QuestionCategoryNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }
        
        public static string QuestionItemClosedQuestionIdRequired
        {
            get
            {
                return Localize("ClosedQuestionId é obrigatório");
            }
        }

        public static string QuestionItemContentStringLength
        {
            get
            {
                return Localize("O campo Content aceita no máximo 255 caracteres.");
            }
        }

        public static string QuestionItemContentRequired
        {
            get
            {
                return Localize("Content é obrigatório");
            }
        }

        public static string QuestionItemIsAnswerRequired
        {
            get
            {
                return Localize("IsAnswer é obrigatório");
            }
        }
        
        public static string QuestionLikertScaleAssessmentQuestionIdRequired
        {
            get
            {
                return Localize("AssessmentQuestionId é obrigatório");
            }
        }

        public static string QuestionLikertScaleLevelRequired
        {
            get
            {
                return Localize("Level é obrigatório");
            }
        }

        public static string QuestionLikertScaleOrderStringLength
        {
            get
            {
                return Localize("O campo Order aceita no máximo 255 caracteres.");
            }
        }

        public static string QuestionLikertScaleOrderRequired
        {
            get
            {
                return Localize("Order é obrigatório");
            }
        }

        public static string QuestionLikertScaleQuestionLikertScaleGroupIdRequired
        {
            get
            {
                return Localize("QuestionLikertScaleGroupId é obrigatório");
            }
        }
        
        public static string QuestionLikertScaleGroupDescriptionStringLength
        {
            get
            {
                return Localize("O campo Description aceita no máximo 255 caracteres.");
            }
        }
        
        public static string QuestionLikertScaleGroupNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 50 caracteres.");
            }
        }

        public static string QuestionLikertScaleGroupNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }
        
        public static string RecurrenceAppointmentRecurrenceIdRequired
        {
            get
            {
                return Localize("AppointmentRecurrenceId é obrigatório");
            }
        }

        public static string RecurrenceDaysOfWeekIdRequired
        {
            get
            {
                return Localize("DaysOfWeekId é obrigatório");
            }
        }

        public static string RecurrenceDescriptionStringLength
        {
            get
            {
                return Localize("O campo Description aceita no máximo 200 caracteres.");
            }
        }

        public static string RecurrenceDescriptionRequired
        {
            get
            {
                return Localize("Description é obrigatório");
            }
        }
        
        public static string RecurrenceRecurrenceStringLength
        {
            get
            {
                return Localize("O campo Recurrence aceita no máximo 50 caracteres.");
            }
        }

        public static string RecurrenceRecurrenceNameStringLength
        {
            get
            {
                return Localize("O campo RecurrenceName aceita no máximo 50 caracteres.");
            }
        }

        public static string RecurrenceRecurrenceNameRequired
        {
            get
            {
                return Localize("RecurrenceName é obrigatório");
            }
        }

        public static string RecurrenceRecurrenceRequired
        {
            get
            {
                return Localize("Recurrence é obrigatório");
            }
        }
        
        public static string RecurrenceStartsOnRequired
        {
            get
            {
                return Localize("StartsOn é obrigatório");
            }
        }

        public static string RegionCountryIdRequired
        {
            get
            {
                return Localize("CountryId é obrigatório");
            }
        }

        public static string RegionNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 50 caracteres.");
            }
        }

        public static string RegionNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }
        
        public static string ReleaseCertificateAuthenticityCodeStringLength
        {
            get
            {
                return Localize("O campo AuthenticityCode aceita no máximo 20 caracteres.");
            }
        }

        public static string ReleaseCertificateAuthenticityCodeRequired
        {
            get
            {
                return Localize("AuthenticityCode é obrigatório");
            }
        }

        public static string ReleaseCertificateCertificateIdRequired
        {
            get
            {
                return Localize("CertificateId é obrigatório");
            }
        }

        public static string ReleaseCertificateCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string ReleaseCertificateCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }

        public static string ReleaseCertificateDateRequired
        {
            get
            {
                return Localize("Date é obrigatório");
            }
        }
        
        public static string ReleaseCertificateShowConclusionRequired
        {
            get
            {
                return Localize("ShowConclusion é obrigatório");
            }
        }

        public static string ReleaseCertificateShowCourseRequired
        {
            get
            {
                return Localize("ShowCourse é obrigatório");
            }
        }

        public static string ReleaseCertificateShowDateRequired
        {
            get
            {
                return Localize("ShowDate é obrigatório");
            }
        }

        public static string ReleaseCertificateShowPerfomanceRequired
        {
            get
            {
                return Localize("ShowPerfomance é obrigatório");
            }
        }

        public static string ReleaseCertificateShowPeriodRequired
        {
            get
            {
                return Localize("ShowPeriod é obrigatório");
            }
        }

        public static string ReleaseCertificateShowUserNameRequired
        {
            get
            {
                return Localize("ShowUserName é obrigatório");
            }
        }

        public static string ReleaseCertificateShowWorkLoadRequired
        {
            get
            {
                return Localize("ShowWorkLoad é obrigatório");
            }
        }

        public static string ReleaseCertificateTrainingIdRequired
        {
            get
            {
                return Localize("TrainingId é obrigatório");
            }
        }

        public static string ResumeCourseCourseIdRequired
        {
            get
            {
                return Localize("CourseId é obrigatório");
            }
        }

        public static string ResumeCourseDescriptionStringLength
        {
            get
            {
                return Localize("O campo Description aceita no máximo -1 caracteres.");
            }
        }

        public static string ResumeCourseDescriptionRequired
        {
            get
            {
                return Localize("Description é obrigatório");
            }
        }
        
        public static string SectionNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 50 caracteres.");
            }
        }

        public static string SectionNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }
        
        public static string SentNewsletterEmailStringLength
        {
            get
            {
                return Localize("O campo Email aceita no máximo 255 caracteres.");
            }
        }

        public static string SentNewsletterEmailRequired
        {
            get
            {
                return Localize("Email é obrigatório");
            }
        }

        public static string SentNewsletterNewsletterIdRequired
        {
            get
            {
                return Localize("NewsletterId é obrigatório");
            }
        }
        
        public static string SentNewsletterSentOnRequired
        {
            get
            {
                return Localize("SentOn é obrigatório");
            }
        }

        public static string SentNewsletterSentToRequired
        {
            get
            {
                return Localize("SentTo é obrigatório");
            }
        }

        public static string ServiceCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string ServiceCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }

        public static string ServiceDescriptionStringLength
        {
            get
            {
                return Localize("O campo Description aceita no máximo 255 caracteres.");
            }
        }

        public static string ServiceNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 50 caracteres.");
            }
        }

        public static string ServiceNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }
        
        public static string ServiceServiceProviderIdRequired
        {
            get
            {
                return Localize("ServiceProviderId é obrigatório");
            }
        }

        public static string ServiceStartDateRequired
        {
            get
            {
                return Localize("StartDate é obrigatório");
            }
        }

        public static string ServiceValueRequired
        {
            get
            {
                return Localize("Value é obrigatório");
            }
        }

        public static string ServiceProviderCnpjStringLength
        {
            get
            {
                return Localize("O campo Cnpj aceita no máximo 14 caracteres.");
            }
        }
        
        public static string ServiceProviderCpfStringLength
        {
            get
            {
                return Localize("O campo Cpf aceita no máximo 11 caracteres.");
            }
        }
        
        public static string ServiceProviderCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string ServiceProviderCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }

        public static string ServiceProviderFirstResponsibleStringLength
        {
            get
            {
                return Localize("O campo FirstResponsible aceita no máximo 50 caracteres.");
            }
        }

        public static string ServiceProviderFirstResponsibleRequired
        {
            get
            {
                return Localize("FirstResponsible é obrigatório");
            }
        }

        public static string ServiceProviderIsLegalEntityRequired
        {
            get
            {
                return Localize("IsLegalEntity é obrigatório");
            }
        }

        public static string ServiceProviderNotesStringLength
        {
            get
            {
                return Localize("O campo Notes aceita no máximo 255 caracteres.");
            }
        }
        
        public static string ServiceProviderSecondResponsibleStringLength
        {
            get
            {
                return Localize("O campo SecondResponsible aceita no máximo 50 caracteres.");
            }
        }

        public static string ServiceProviderUserPaycheckRequired
        {
            get
            {
                return Localize("UserPaycheck é obrigatório");
            }
        }

        public static string ServiceProviderBankBankIdRequired
        {
            get
            {
                return Localize("BankId é obrigatório");
            }
        }
        
        public static string ServiceProviderBankIsActiveRequired
        {
            get
            {
                return Localize("IsActive é obrigatório");
            }
        }

        public static string ServiceProviderBankIsMainProviderRequired
        {
            get
            {
                return Localize("IsMainProvider é obrigatório");
            }
        }

        public static string ServiceProviderBankServiceProviderIdRequired
        {
            get
            {
                return Localize("ServiceProviderId é obrigatório");
            }
        }
        
        public static string SocialMemberMembershipUserIdRequired
        {
            get
            {
                return Localize("MembershipUserId é obrigatório");
            }
        }

        public static string SocialMemberNickNameStringLength
        {
            get
            {
                return Localize("O campo Nickname aceita no máximo 50 caracteres.");
            }
        }

        public static string SocialMemberNickNameRequired
        {
            get
            {
                return Localize("Nickname é obrigatório");
            }
        }

        public static string SocialMemberPasswordStringLength
        {
            get
            {
                return Localize("O campo Password aceita no máximo 100 caracteres.");
            }
        }

        public static string SocialMemberPasswordRequired
        {
            get
            {
                return Localize("Password é obrigatório");
            }
        }
        
        public static string SocialMemberSocialNetworkIdRequired
        {
            get
            {
                return Localize("SocialNetworkId é obrigatório");
            }
        }

        public static string SocialMemberUrlStringLength
        {
            get
            {
                return Localize("O campo Url aceita no máximo 100 caracteres.");
            }
        }
        
        public static string SocialNetworkCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string SocialNetworkCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }

        public static string SocialNetworkDescriptionStringLength
        {
            get
            {
                return Localize("O campo Description aceita no máximo 100 caracteres.");
            }
        }
        
        public static string SocialNetworkImagePathStringLength
        {
            get
            {
                return Localize("O campo ImagePath aceita no máximo 255 caracteres.");
            }
        }
        
        public static string SocialNetworkNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 50 caracteres.");
            }
        }

        public static string SocialNetworkNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }
        
        public static string SpecialAssessmentAssessmentIdRequired
        {
            get
            {
                return Localize("AssessmentId é obrigatório");
            }
        }

        public static string SpecialAssessmentMaxScoreRequired
        {
            get
            {
                return Localize("MaxScore é obrigatório");
            }
        }

        public static string SpecialAssessmentMinimumScoreRequired
        {
            get
            {
                return Localize("MinimumScore é obrigatório");
            }
        }

        public static string SpecialAssessmentPercentageRequired
        {
            get
            {
                return Localize("Percentage é obrigatório");
            }
        }
        
        public static string SpecialAssessmentSubstituteAssessmentIdRequired
        {
            get
            {
                return Localize("SubstituteAssessmentId é obrigatório");
            }
        }

        public static string StateNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 50 caracteres.");
            }
        }

        public static string StateNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }

        public static string StateRegionIdRequired
        {
            get
            {
                return Localize("RegionId é obrigatório");
            }
        }
        
        public static string SurveyAllowJustificationRequired
        {
            get
            {
                return Localize("AllowJustification é obrigatório");
            }
        }

        public static string SurveyCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string SurveyCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }
        
        public static string SurveyImagePathStringLength
        {
            get
            {
                return Localize("O campo ImagePath aceita no máximo 255 caracteres.");
            }
        }
        
        public static string SurveyIsActiveRequired
        {
            get
            {
                return Localize("IsActive é obrigatório");
            }
        }

        public static string SurveyIsAPollRequired
        {
            get
            {
                return Localize("IsAPoll é obrigatório");
            }
        }

        public static string SurveyIsMandatoryRequired
        {
            get
            {
                return Localize("IsMandatory é obrigatório");
            }
        }
        
        public static string SurveyStartsOnRequired
        {
            get
            {
                return Localize("StartsOn é obrigatório");
            }
        }
        
        public static string SurveyTitleStringLength
        {
            get
            {
                return Localize("O campo Title aceita no máximo 255 caracteres.");
            }
        }

        public static string SurveyTitleRequired
        {
            get
            {
                return Localize("Title é obrigatório");
            }
        }

        public static string SurveyTypeRequired
        {
            get
            {
                return Localize("Type é obrigatório");
            }
        }

        public static string SurveyAreaAreaIdRequired
        {
            get
            {
                return Localize("AreaId é obrigatório");
            }
        }
        
        public static string SurveyAreaSurveyIdRequired
        {
            get
            {
                return Localize("SurveyId é obrigatório");
            }
        }
        
        public static string SurveyClassClassIdRequired
        {
            get
            {
                return Localize("ClassId é obrigatório");
            }
        }
        
        public static string SurveyClassSurveyIdRequired
        {
            get
            {
                return Localize("SurveyId é obrigatório");
            }
        }
        
        public static string SurveyCourseCourseIdRequired
        {
            get
            {
                return Localize("CourseId é obrigatório");
            }
        }
        
        public static string SurveyCourseSurveyIdRequired
        {
            get
            {
                return Localize("SurveyId é obrigatório");
            }
        }
        
        public static string SurveyProfileProfileIdRequired
        {
            get
            {
                return Localize("ProfileId é obrigatório");
            }
        }
        
        public static string SurveyProfileSurveyIdRequired
        {
            get
            {
                return Localize("SurveyId é obrigatório");
            }
        }
        
        public static string SurveyProgramProgramIdRequired
        {
            get
            {
                return Localize("ProgramId é obrigatório");
            }
        }
        
        public static string SurveyProgramSurveyIdRequired
        {
            get
            {
                return Localize("SurveyId é obrigatório");
            }
        }
        
        public static string SurveyUnitSurveyIdRequired
        {
            get
            {
                return Localize("SurveyId é obrigatório");
            }
        }
        
        public static string SurveyUnitUnitIdRequired
        {
            get
            {
                return Localize("UnitId é obrigatório");
            }
        }
        
        public static string SurveyItemAllowCommentRequired
        {
            get
            {
                return Localize("AllowComment é obrigatório");
            }
        }

        public static string SurveyItemImagePathStringLength
        {
            get
            {
                return Localize("O campo ImagePath aceita no máximo 255 caracteres.");
            }
        }
        
        public static string SurveyItemPositionRequired
        {
            get
            {
                return Localize("Position é obrigatório");
            }
        }

        public static string SurveyItemQuestionStringLength
        {
            get
            {
                return Localize("O campo Question aceita no máximo 255 caracteres.");
            }
        }

        public static string SurveyItemQuestionRequired
        {
            get
            {
                return Localize("Question é obrigatório");
            }
        }

        public static string SurveyItemSurveyIdRequired
        {
            get
            {
                return Localize("SurveyId é obrigatório");
            }
        }
        
        public static string SurveyItemAltSurveyUserSurveyItemAlternativeIdRequired
        {
            get
            {
                return Localize("SurveyItemAlternativeId é obrigatório");
            }
        }
        
        public static string SurveyItemAltSurveyUserSurveyUserIdRequired
        {
            get
            {
                return Localize("SurveyUserId é obrigatório");
            }
        }
        
        public static string SurveyItemAlternativeAlternativeStringLength
        {
            get
            {
                return Localize("O campo Alternative aceita no máximo 255 caracteres.");
            }
        }

        public static string SurveyItemAlternativeAlternativeRequired
        {
            get
            {
                return Localize("Alternative é obrigatório");
            }
        }

        public static string SurveyItemAlternativeImagePathStringLength
        {
            get
            {
                return Localize("O campo ImagePath aceita no máximo 255 caracteres.");
            }
        }

        public static string SurveyItemAlternativeSurveyItemIdRequired
        {
            get
            {
                return Localize("SurveyItemId é obrigatório");
            }
        }

        public static string SurveyUserIPStringLength
        {
            get
            {
                return Localize("O campo IP aceita no máximo 39 caracteres.");
            }
        }

        public static string SurveyUserIPRequired
        {
            get
            {
                return Localize("IP é obrigatório");
            }
        }

        public static string SurveyUserJustificationStringLength
        {
            get
            {
                return Localize("O campo Justification aceita no máximo 500 caracteres.");
            }
        }

        public static string SurveyUserJustificationRequired
        {
            get
            {
                return Localize("Justification é obrigatório");
            }
        }

        public static string SurveyUserRealizedOnRequired
        {
            get
            {
                return Localize("RealizedOn é obrigatório");
            }
        }
        
        public static string SurveyUserUserIdRequired
        {
            get
            {
                return Localize("UserId é obrigatório");
            }
        }

        public static string sysdiagramsdefinitionStringLength
        {
            get
            {
                return Localize("O campo definition aceita no máximo -1 caracteres.");
            }
        }

        public static string sysdiagramsnameStringLength
        {
            get
            {
                return Localize("O campo name aceita no máximo 128 caracteres.");
            }
        }

        public static string sysdiagramsnameRequired
        {
            get
            {
                return Localize("name é obrigatório");
            }
        }

        public static string sysdiagramsprincipalidRequired
        {
            get
            {
                return Localize("principalid é obrigatório");
            }
        }
        
        public static string sysdiagramsversionRequired
        {
            get
            {
                return Localize("version é obrigatório");
            }
        }

        public static string SystemPropertyBinaryValueStringLength
        {
            get
            {
                return Localize("O campo BinaryValue aceita no máximo 1 caracteres.");
            }
        }

        public static string SystemPropertyBinaryValueRequired
        {
            get
            {
                return Localize("BinaryValue é obrigatório");
            }
        }

        public static string SystemPropertyPropertyStringLength
        {
            get
            {
                return Localize("O campo Property aceita no máximo 100 caracteres.");
            }
        }

        public static string SystemPropertyPropertyRequired
        {
            get
            {
                return Localize("Property é obrigatório");
            }
        }

        public static string SystemPropertyPropertyTypeStringLength
        {
            get
            {
                return Localize("O campo PropertyType aceita no máximo 20 caracteres.");
            }
        }

        public static string SystemPropertyPropertyTypeRequired
        {
            get
            {
                return Localize("PropertyType é obrigatório");
            }
        }

        public static string SystemPropertyStringValueStringLength
        {
            get
            {
                return Localize("O campo StringValue aceita no máximo 255 caracteres.");
            }
        }

        public static string SystemPropertyStringValueRequired
        {
            get
            {
                return Localize("StringValue é obrigatório");
            }
        }
        
        public static string TagCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string TagCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }

        public static string TagNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 50 caracteres.");
            }
        }

        public static string TagNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }
        
        public static string TaskDispatcherDescriptionStringLength
        {
            get
            {
                return Localize("O campo Description aceita no máximo 500 caracteres.");
            }
        }
        
        public static string TaskDispatcherIsActiveRequired
        {
            get
            {
                return Localize("IsActive é obrigatório");
            }
        }

        public static string TaskDispatcherNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 100 caracteres.");
            }
        }

        public static string TaskDispatcherNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }

        public static string TaskDispatcherRecurrenceIdRequired
        {
            get
            {
                return Localize("RecurrenceId é obrigatório");
            }
        }
        
        public static string TaskDispatcherUrlStringLength
        {
            get
            {
                return Localize("O campo Url aceita no máximo 200 caracteres.");
            }
        }
        
        public static string TaskDispatcherLogExecutionDateRequired
        {
            get
            {
                return Localize("ExecutionDate é obrigatório");
            }
        }

        public static string TaskDispatcherLogTaskDispatcherIdRequired
        {
            get
            {
                return Localize("TaskDispatcherId é obrigatório");
            }
        }
        
        public static string TextMatchKeyWordsQuestionPostionRequired
        {
            get
            {
                return Localize("Postion é obrigatório");
            }
        }

        public static string TextMatchKeyWordsQuestionTextStringLength
        {
            get
            {
                return Localize("O campo Text aceita no máximo 255 caracteres.");
            }
        }

        public static string TextMatchKeyWordsQuestionTextRequired
        {
            get
            {
                return Localize("Text é obrigatório");
            }
        }
        
        public static string TextMatchKeyWordsQuestionTextMatchQuestionIdRequired
        {
            get
            {
                return Localize("TextMatchQuestionId é obrigatório");
            }
        }

        public static string TextMatchKeyWordsSynonymsSynonymousStringLength
        {
            get
            {
                return Localize("O campo Synonymous aceita no máximo 100 caracteres.");
            }
        }

        public static string TextMatchKeyWordsSynonymsSynonymousRequired
        {
            get
            {
                return Localize("Synonymous é obrigatório");
            }
        }

        public static string TextMatchKeyWordsSynonymsTextMatchKeyWordsQuestionIdRequired
        {
            get
            {
                return Localize("TextMatchKeyWordsQuestionId é obrigatório");
            }
        }
        
        public static string TextMatchQuestionClosedQuestionIdRequired
        {
            get
            {
                return Localize("ClosedQuestionId é obrigatório");
            }
        }

        public static string TextMatchQuestionObservationStringLength
        {
            get
            {
                return Localize("O campo Observation aceita no máximo 255 caracteres.");
            }
        }

        public static string TextMatchQuestionObservationRequired
        {
            get
            {
                return Localize("Observation é obrigatório");
            }
        }

        public static string TextMatchQuestionTextStringLength
        {
            get
            {
                return Localize("O campo Text aceita no máximo 255 caracteres.");
            }
        }

        public static string TextMatchQuestionTextRequired
        {
            get
            {
                return Localize("Text é obrigatório");
            }
        }
        
        public static string TextMatchQuestionAttemptsPositionRequired
        {
            get
            {
                return Localize("Position é obrigatório");
            }
        }

        public static string TextMatchQuestionAttemptsQuestionAttemptsIdRequired
        {
            get
            {
                return Localize("QuestionAttemptsId é obrigatório");
            }
        }

        public static string TextMatchQuestionAttemptsTextMatchKeyWordsQuestionIdRequired
        {
            get
            {
                return Localize("TextMatchKeyWordsQuestionId é obrigatório");
            }
        }
        
        public static string ThemeNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 50 caracteres.");
            }
        }

        public static string ThemeNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }

        public static string ThemePropertiesStringLength
        {
            get
            {
                return Localize("O campo Properties aceita no máximo 250 caracteres.");
            }
        }

        public static string ThemePropertiesRequired
        {
            get
            {
                return Localize("Properties é obrigatório");
            }
        }
        
        public static string TrainingAccessTimeRequired
        {
            get
            {
                return Localize("AccessTime é obrigatório");
            }
        }

        public static string TrainingConclusionPercentageRequired
        {
            get
            {
                return Localize("ConclusionPercentage é obrigatório");
            }
        }

        public static string TrainingCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }
        
        public static string TrainingIsApprovedRequired
        {
            get
            {
                return Localize("IsApproved é obrigatório");
            }
        }

        public static string TrainingIsImportedRequired
        {
            get
            {
                return Localize("IsImported é obrigatório");
            }
        }
        
        public static string TrainingLegacySystemIDStringLength
        {
            get
            {
                return Localize("O campo LegacySystemID aceita no máximo 100 caracteres.");
            }
        }
        
        public static string TrainingPreTestScoreRequired
        {
            get
            {
                return Localize("PreTestScore é obrigatório");
            }
        }

        public static string TrainingRegisteredOnRequired
        {
            get
            {
                return Localize("RegisteredOn é obrigatório");
            }
        }

        public static string TrainingRegistrationTypeRequired
        {
            get
            {
                return Localize("RegistrationType é obrigatório");
            }
        }
        
        public static string TrainingStatusRequired
        {
            get
            {
                return Localize("Status é obrigatório");
            }
        }

        public static string TrainingTotalAccessRequired
        {
            get
            {
                return Localize("TotalAccess é obrigatório");
            }
        }

        public static string TrainingTotalScoreRequired
        {
            get
            {
                return Localize("TotalScore é obrigatório");
            }
        }
        
        public static string TrainingUserIdRequired
        {
            get
            {
                return Localize("UserId é obrigatório");
            }
        }

        public static string TrainingDeadlineClassIdRequired
        {
            get
            {
                return Localize("ClassId é obrigatório");
            }
        }

        public static string TrainingDeadlineCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string TrainingDeadlineCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }

        public static string TrainingDeadlineDateRequired
        {
            get
            {
                return Localize("Date é obrigatório");
            }
        }

        public static string TrainingDeadlineOnlineAssessmentIdRequired
        {
            get
            {
                return Localize("OnlineAssessmentId é obrigatório");
            }
        }
        
        public static string TrainingDeadlineUserIdRequired
        {
            get
            {
                return Localize("UserId é obrigatório");
            }
        }

        public static string TrainingRealizationAccessTimeRequired
        {
            get
            {
                return Localize("AccessTime é obrigatório");
            }
        }

        public static string TrainingRealizationAICCTimeBufferStringLength
        {
            get
            {
                return Localize("O campo AICCTimeBuffer aceita no máximo 13 caracteres.");
            }
        }
        
        public static string TrainingRealizationBookmarkRequired
        {
            get
            {
                return Localize("Bookmark é obrigatório");
            }
        }

        public static string TrainingRealizationCoreEntryStringLength
        {
            get
            {
                return Localize("O campo CoreEntry aceita no máximo 10 caracteres.");
            }
        }
        
        public static string TrainingRealizationCoreExitStringLength
        {
            get
            {
                return Localize("O campo CoreExit aceita no máximo 10 caracteres.");
            }
        }
        
        public static string TrainingRealizationCoreLessonLocationStringLength
        {
            get
            {
                return Localize("O campo CoreLessonLocation aceita no máximo 255 caracteres.");
            }
        }
        
        public static string TrainingRealizationCoreLessonStatusStringLength
        {
            get
            {
                return Localize("O campo CoreLessonStatus aceita no máximo 15 caracteres.");
            }
        }
        
        public static string TrainingRealizationCoreTotalTimeStringLength
        {
            get
            {
                return Localize("O campo CoreTotalTime aceita no máximo 13 caracteres.");
            }
        }
        
        public static string TrainingRealizationRevisedByRequired
        {
            get
            {
                return Localize("RevisedBy é obrigatório");
            }
        }

        public static string TrainingRealizationTotalAccessRequired
        {
            get
            {
                return Localize("TotalAccess é obrigatório");
            }
        }

        public static string TrainingRealizationTrainingIdRequired
        {
            get
            {
                return Localize("TrainingId é obrigatório");
            }
        }
        
        public static string TrainingRealizationSolidDataIPStringLength
        {
            get
            {
                return Localize("O campo IP aceita no máximo 15 caracteres.");
            }
        }
        
        public static string TrainingRealizationSolidDataRealizedOnRequired
        {
            get
            {
                return Localize("RealizedOn é obrigatório");
            }
        }

        public static string TrainingRealizationSolidDataScoreRequired
        {
            get
            {
                return Localize("Score é obrigatório");
            }
        }

        public static string TrainingRealizationSolidDataStatusRequired
        {
            get
            {
                return Localize("Status é obrigatório");
            }
        }

        public static string TrainingRealizationSolidDataTrainingRealizationIdRequired
        {
            get
            {
                return Localize("TrainingRealizationId é obrigatório");
            }
        }
        
        public static string TutoringLocalAssessmentIdRequired
        {
            get
            {
                return Localize("LocalAssessmentId é obrigatório");
            }
        }

        public static string TutoringRoleRequired
        {
            get
            {
                return Localize("Role é obrigatório");
            }
        }

        public static string TutoringTutorIdRequired
        {
            get
            {
                return Localize("TutorId é obrigatório");
            }
        }
        
        public static string TypeLogCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string TypeLogCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }

        public static string TypeLogFullNameStringLength
        {
            get
            {
                return Localize("O campo FullName aceita no máximo 100 caracteres.");
            }
        }

        public static string TypeLogFullNameRequired
        {
            get
            {
                return Localize("FullName é obrigatório");
            }
        }

        public static string TypeLogNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 50 caracteres.");
            }
        }

        public static string TypeLogNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }
        
        public static string UnitCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string UnitCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }

        public static string UnitIsActiveRequired
        {
            get
            {
                return Localize("IsActive é obrigatório");
            }
        }

        public static string UnitLegacySystemIdStringLength
        {
            get
            {
                return Localize("O campo LegacySystemID aceita no máximo 100 caracteres.");
            }
        }
        
        public static string UnitNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 100 caracteres.");
            }
        }

        public static string UnitNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }
        
        public static string UnitUnitParentIdRequired
        {
            get
            {
                return Localize("UnitParentID é obrigatório");
            }
        }

        public static string UnitUserUnitIdRequired
        {
            get
            {
                return Localize("UnitId é obrigatório");
            }
        }
        
        public static string UnitUserUserIdRequired
        {
            get
            {
                return Localize("UserId é obrigatório");
            }
        }
        
        public static string UserCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string UserCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }

        public static string UserIsAnonymousRequired
        {
            get
            {
                return Localize("IsAnonymous é obrigatório");
            }
        }
        
        public static string UserUnitIdRequired
        {
            get
            {
                return Localize("UnitID é obrigatório");
            }
        }
        
        public static string UserUserNameStringLength
        {
            get
            {
                return Localize("O campo UserName aceita no máximo 50 caracteres.");
            }
        }

        public static string UserUserNameRequired
        {
            get
            {
                return Localize("UserName é obrigatório");
            }
        }

        public static string UserCustomizationProfilePropertyIdRequired
        {
            get
            {
                return Localize("ProfilePropertyId é obrigatório");
            }
        }
        
        public static string UserCustomizationPropertyListIdRequired
        {
            get
            {
                return Localize("PropertyListID é obrigatório");
            }
        }
        
        public static string UserCustomizationUserIdRequired
        {
            get
            {
                return Localize("UserId é obrigatório");
            }
        }

        public static string UserCustomizationValueStringLength
        {
            get
            {
                return Localize("O campo Value aceita no máximo 500 caracteres.");
            }
        }
        
        public static string UserFeedbackAnsweredOnRequired
        {
            get
            {
                return Localize("AnsweredOn é obrigatório");
            }
        }

        public static string UserFeedbackFeedbackItemIdRequired
        {
            get
            {
                return Localize("FeedbackItemId é obrigatório");
            }
        }

        public static string UserFeedbackTrainingIdRequired
        {
            get
            {
                return Localize("TrainingId é obrigatório");
            }
        }
        
        public static string UserMessageIsDeletedRequired
        {
            get
            {
                return Localize("IsDeleted é obrigatório");
            }
        }

        public static string UserMessageIsReadRequired
        {
            get
            {
                return Localize("IsRead é obrigatório");
            }
        }

        public static string UserMessageMessageIdRequired
        {
            get
            {
                return Localize("MessageId é obrigatório");
            }
        }

        public static string UserMessageSentOnRequired
        {
            get
            {
                return Localize("SentOn é obrigatório");
            }
        }

        public static string UserMessageSentToRequired
        {
            get
            {
                return Localize("SentTo é obrigatório");
            }
        }

        public static string UserMessageUserTypeMessageIdRequired
        {
            get
            {
                return Localize("UserTypeMessageId é obrigatório");
            }
        }

        public static string UsersPermissionsActionNameStringLength
        {
            get
            {
                return Localize("O campo ActionName aceita no máximo 50 caracteres.");
            }
        }

        public static string UsersPermissionsActionNameRequired
        {
            get
            {
                return Localize("ActionName é obrigatório");
            }
        }

        public static string UsersPermissionsComponentNameStringLength
        {
            get
            {
                return Localize("O campo ComponentName aceita no máximo 50 caracteres.");
            }
        }

        public static string UsersPermissionsComponentNameRequired
        {
            get
            {
                return Localize("ComponentName é obrigatório");
            }
        }

        public static string UsersPermissionsIsAllowedRequired
        {
            get
            {
                return Localize("IsAllowed é obrigatório");
            }
        }

        public static string UsersPermissionsModuleNameStringLength
        {
            get
            {
                return Localize("O campo ModuleName aceita no máximo 50 caracteres.");
            }
        }
        
        public static string UsersPermissionsTypeRequired
        {
            get
            {
                return Localize("Type é obrigatório");
            }
        }

        public static string UsersPermissionsUserIdRequired
        {
            get
            {
                return Localize("UserId é obrigatório");
            }
        }

        public static string UserTypeMessageCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }

        public static string UserTypeMessageNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 200 caracteres.");
            }
        }

        public static string UserTypeMessageNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }
        
        public static string UserUseTermsAcceptedOnRequired
        {
            get
            {
                return Localize("AcceptedOn é obrigatório");
            }
        }

        public static string UserUseTermsUserIdRequired
        {
            get
            {
                return Localize("UserId é obrigatório");
            }
        }

        public static string UserUseTermsUseTermsIdRequired
        {
            get
            {
                return Localize("UseTermsId é obrigatório");
            }
        }

        public static string UserWorkpaperUserIdRequired
        {
            get
            {
                return Localize("UserId é obrigatório");
            }
        }

        public static string UserWorkpaperWorkpaperIdRequired
        {
            get
            {
                return Localize("WorkpaperId é obrigatório");
            }
        }

        public static string UseTermsContentStringLength
        {
            get
            {
                return Localize("O campo Content aceita no máximo -1 caracteres.");
            }
        }

        public static string UseTermsContentRequired
        {
            get
            {
                return Localize("Content é obrigatório");
            }
        }

        public static string UseTermsCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string UseTermsCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }

        public static string UseTermsNotifyUsersRequired
        {
            get
            {
                return Localize("NotifyUsers é obrigatório");
            }
        }

        public static string UseTermsTitleStringLength
        {
            get
            {
                return Localize("O campo Title aceita no máximo 255 caracteres.");
            }
        }

        public static string UseTermsTitleRequired
        {
            get
            {
                return Localize("Title é obrigatório");
            }
        }
        
        public static string WidgetCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string WidgetCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }

        public static string WidgetFinishesOnRequired
        {
            get
            {
                return Localize("FinishesOn é obrigatório");
            }
        }

        public static string WidgetIsActiveRequired
        {
            get
            {
                return Localize("IsActive é obrigatório");
            }
        }

        public static string WidgetModelStringLength
        {
            get
            {
                return Localize("O campo Model aceita no máximo 500 caracteres.");
            }
        }

        public static string WidgetModelRequired
        {
            get
            {
                return Localize("Model é obrigatório");
            }
        }

        public static string WidgetNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 100 caracteres.");
            }
        }

        public static string WidgetNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }

        public static string WidgetPermissionIdRequired
        {
            get
            {
                return Localize("PermissionId é obrigatório");
            }
        }

        public static string WidgetStartsOnRequired
        {
            get
            {
                return Localize("StartsOn é obrigatório");
            }
        }
        
        public static string WidgetZoneIdRequired
        {
            get
            {
                return Localize("ZoneId é obrigatório");
            }
        }
        
        public static string WikiApprovedByRequired
        {
            get
            {
                return Localize("ApprovedBy é obrigatório");
            }
        }
        
        public static string WikiBatchSetupIdRequired
        {
            get
            {
                return Localize("BatchSetupID é obrigatório");
            }
        }

        public static string WikiCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string WikiCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }

        public static string WikiPositionRequired
        {
            get
            {
                return Localize("Position é obrigatório");
            }
        }

        public static string WikiWikiCategoryIdRequired
        {
            get
            {
                return Localize("WikiCategoryId é obrigatório");
            }
        }
        
        public static string WikiWikiParentIdRequired
        {
            get
            {
                return Localize("WikiParentID é obrigatório");
            }
        }

        public static string WikiClassClassIdRequired
        {
            get
            {
                return Localize("ClassId é obrigatório");
            }
        }
        
        public static string WikiClassWikiIdRequired
        {
            get
            {
                return Localize("WikiId é obrigatório");
            }
        }
        
        public static string WikiCourseCourseIdRequired
        {
            get
            {
                return Localize("CourseId é obrigatório");
            }
        }
        
        public static string WikiCourseWikiIdRequired
        {
            get
            {
                return Localize("WikiId é obrigatório");
            }
        }
        
        public static string WikiProfileProfileIdRequired
        {
            get
            {
                return Localize("ProfileId é obrigatório");
            }
        }
        
        public static string WikiProfileWikiIdRequired
        {
            get
            {
                return Localize("WikiId é obrigatório");
            }
        }
        
        public static string WikiProgramProgramIdRequired
        {
            get
            {
                return Localize("ProgramId é obrigatório");
            }
        }
        
        public static string WikiProgramWikiIdRequired
        {
            get
            {
                return Localize("WikiId é obrigatório");
            }
        }
        
        public static string WikiUnitUnitIdRequired
        {
            get
            {
                return Localize("UnitId é obrigatório");
            }
        }
        
        public static string WikiUnitWikiIdRequired
        {
            get
            {
                return Localize("WikiId é obrigatório");
            }
        }
        
        public static string WikiAccessAccessedByRequired
        {
            get
            {
                return Localize("AccessedBy é obrigatório");
            }
        }

        public static string WikiAccessAccessedOnRequired
        {
            get
            {
                return Localize("AccessedOn é obrigatório");
            }
        }
        
        public static string WikiAccessWikiIdRequired
        {
            get
            {
                return Localize("WikiId é obrigatório");
            }
        }

        public static string WikiCategoryNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 255 caracteres.");
            }
        }

        public static string WikiCategoryNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }
        
        public static string WikiCommentCommentedByRequired
        {
            get
            {
                return Localize("CommentedBy é obrigatório");
            }
        }

        public static string WikiCommentCommentedOnRequired
        {
            get
            {
                return Localize("CommentedOn é obrigatório");
            }
        }

        public static string WikiCommentTextStringLength
        {
            get
            {
                return Localize("O campo Text aceita no máximo 500 caracteres.");
            }
        }

        public static string WikiCommentTextRequired
        {
            get
            {
                return Localize("Text é obrigatório");
            }
        }
        
        public static string WikiCommentWikiContentIdRequired
        {
            get
            {
                return Localize("WikiContentId é obrigatório");
            }
        }
        
        public static string WikiContentApprovedByRequired
        {
            get
            {
                return Localize("ApprovedBy é obrigatório");
            }
        }
        
        public static string WikiContentContentStringLength
        {
            get
            {
                return Localize("O campo Content aceita no máximo -1 caracteres.");
            }
        }

        public static string WikiContentContentRequired
        {
            get
            {
                return Localize("Content é obrigatório");
            }
        }

        public static string WikiContentCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string WikiContentCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }

        public static string WikiContentIsApprovedRequired
        {
            get
            {
                return Localize("IsApproved é obrigatório");
            }
        }

        public static string WikiContentModifiedByRequired
        {
            get
            {
                return Localize("ModifiedBy é obrigatório");
            }
        }

        public static string WikiContentModifiedOnRequired
        {
            get
            {
                return Localize("ModifiedOn é obrigatório");
            }
        }

        public static string WikiContentReviewedByRequired
        {
            get
            {
                return Localize("ReviewedBy é obrigatório");
            }
        }

        public static string WikiContentReviewedOnRequired
        {
            get
            {
                return Localize("ReviewedOn é obrigatório");
            }
        }

        public static string WikiContentStatusRequired
        {
            get
            {
                return Localize("Status é obrigatório");
            }
        }

        public static string WikiContentSummaryStringLength
        {
            get
            {
                return Localize("O campo Summary aceita no máximo 500 caracteres.");
            }
        }

        public static string WikiContentSummaryRequired
        {
            get
            {
                return Localize("Summary é obrigatório");
            }
        }

        public static string WikiContentTitleStringLength
        {
            get
            {
                return Localize("O campo Title aceita no máximo 255 caracteres.");
            }
        }

        public static string WikiContentTitleRequired
        {
            get
            {
                return Localize("Title é obrigatório");
            }
        }
        
        public static string WikiContentWikiIdRequired
        {
            get
            {
                return Localize("WikiId é obrigatório");
            }
        }

        public static string WikiContentWikiVersionIdRequired
        {
            get
            {
                return Localize("WikiVersionId é obrigatório");
            }
        }

        public static string WikiContentTagTagIdRequired
        {
            get
            {
                return Localize("TagId é obrigatório");
            }
        }
        
        public static string WikiContentTagWikiContentIdRequired
        {
            get
            {
                return Localize("WikiContentId é obrigatório");
            }
        }
        
        public static string WikiVersionCommentStringLength
        {
            get
            {
                return Localize("O campo Comment aceita no máximo 500 caracteres.");
            }
        }
        
        public static string WikiVersionUserIdRequired
        {
            get
            {
                return Localize("UserId é obrigatório");
            }
        }

        public static string WikiVersionVersionDateRequired
        {
            get
            {
                return Localize("VersionDate é obrigatório");
            }
        }
        
        public static string WorkpaperAllowDeliveryDelayRequired
        {
            get
            {
                return Localize("AllowDeliveryDelay é obrigatório");
            }
        }

        public static string WorkpaperAllowReSubmitRequired
        {
            get
            {
                return Localize("AllowReSubmit é obrigatório");
            }
        }

        public static string WorkpaperAppliedByRequired
        {
            get
            {
                return Localize("AppliedBy é obrigatório");
            }
        }

        public static string WorkpaperApprovalScoreRequired
        {
            get
            {
                return Localize("ApprovalScore é obrigatório");
            }
        }

        public static string WorkpaperIsActiveRequired
        {
            get
            {
                return Localize("IsActive é obrigatório");
            }
        }

        public static string WorkpaperIsUsedOnFinalScoreRequired
        {
            get
            {
                return Localize("IsUsedOnFinalScore é obrigatório");
            }
        }

        public static string WorkpaperLearningObjectIdRequired
        {
            get
            {
                return Localize("LearningObjectId é obrigatório");
            }
        }
        
        public static string WorkpaperMediaIdRequired
        {
            get
            {
                return Localize("MediaID é obrigatório");
            }
        }

        public static string WorkpaperOpeningTextStringLength
        {
            get
            {
                return Localize("O campo OpeningText aceita no máximo 500 caracteres.");
            }
        }
        
        public static string WorkpaperReceiveAfterDeadlineRequired
        {
            get
            {
                return Localize("ReceiveAfterDeadline é obrigatório");
            }
        }

        public static string WorkpaperScoreRequired
        {
            get
            {
                return Localize("Score é obrigatório");
            }
        }

        public static string WorkpaperTitleStringLength
        {
            get
            {
                return Localize("O campo Title aceita no máximo 255 caracteres.");
            }
        }

        public static string WorkpaperTitleRequired
        {
            get
            {
                return Localize("Title é obrigatório");
            }
        }
        
        public static string WorkpaperRealizationDeliveredOnRequired
        {
            get
            {
                return Localize("DeliveredOn é obrigatório");
            }
        }

        public static string WorkpaperRealizationFilePathStringLength
        {
            get
            {
                return Localize("O campo FilePath aceita no máximo 255 caracteres.");
            }
        }

        public static string WorkpaperRealizationFilePathRequired
        {
            get
            {
                return Localize("FilePath é obrigatório");
            }
        }

        public static string WorkpaperRealizationRevisedByRequired
        {
            get
            {
                return Localize("RevisedBy é obrigatório");
            }
        }
        
        public static string WorkpaperRealizationTrainingIdRequired
        {
            get
            {
                return Localize("TrainingId é obrigatório");
            }
        }

        public static string WorkpaperRealizationWorkpaperIdRequired
        {
            get
            {
                return Localize("WorkpaperId é obrigatório");
            }
        }
        
        public static string WorkpaperRejectedReasonStringLength
        {
            get
            {
                return Localize("O campo Reason aceita no máximo 255 caracteres.");
            }
        }

        public static string WorkpaperRejectedReasonRequired
        {
            get
            {
                return Localize("Reason é obrigatório");
            }
        }

        public static string WorkpaperRejectedRejectedOnRequired
        {
            get
            {
                return Localize("RejectedOn é obrigatório");
            }
        }

        public static string WorkpaperRejectedWorkpaperRealizationIdRequired
        {
            get
            {
                return Localize("WorkpaperRealizationId é obrigatório");
            }
        }
        
        public static string ZoneCreatedByRequired
        {
            get
            {
                return Localize("CreatedBy é obrigatório");
            }
        }

        public static string ZoneCreatedOnRequired
        {
            get
            {
                return Localize("CreatedOn é obrigatório");
            }
        }

        public static string ZoneNameStringLength
        {
            get
            {
                return Localize("O campo Name aceita no máximo 100 caracteres.");
            }
        }

        public static string ZoneNameRequired
        {
            get
            {
                return Localize("Name é obrigatório");
            }
        }

        /// <summary>
        /// Titulo do index de Períodos de Acesso
        /// </summary>
        public static string AccessIndexTitle
        {
            get
            {
                return Localize("Períodos de Acesso");
            }
        }

        /// <summary>
        /// Titulo do Create de Períodos de Acesso
        /// </summary>
        public static string AccessCreateTitle
        {
            get
            {
                return Localize("Cadastro de Períodos de Acesso");
            }
        }

        /// <summary>
        /// Titulo do Edit de Períodos de Acesso
        /// </summary>
        public static string AccessEditTitle
        {
            get
            {
                return Localize("Edição de Períodos de Acesso");
            }
        }

        /// <summary>
        /// Label do botão Create de Períodos de Acesso
        /// </summary>
        public static string AccessCreateButton
        {
            get
            {
                return Localize("Novo Períodos de Acesso");
            }
        }

        /// <summary>
        /// Label do botão Delete de Períodos de Acesso
        /// </summary>
        public static string AccessDeleteButton
        {
            get
            {
                return Localize("Excluir Períodos de Acesso");
            }
        }

        /// <summary>
        /// Titulo do index de Action
        /// </summary>
        public static string ActionIndexTitle
        {
            get
            {
                return Localize("Action");
            }
        }

        /// <summary>
        /// Titulo do Create de Action
        /// </summary>
        public static string ActionCreateTitle
        {
            get
            {
                return Localize("Cadastro de Action");
            }
        }

        /// <summary>
        /// Titulo do Edit de Action
        /// </summary>
        public static string ActionEditTitle
        {
            get
            {
                return Localize("Edição de Action");
            }
        }

        /// <summary>
        /// Label do botão Create de Action
        /// </summary>
        public static string ActionCreateButton
        {
            get
            {
                return Localize("Novo Action");
            }
        }

        /// <summary>
        /// Label do botão Delete de Action
        /// </summary>
        public static string ActionDeleteButton
        {
            get
            {
                return Localize("Excluir Action");
            }
        }

        /// <summary>
        /// Titulo do index de Atividade
        /// </summary>
        public static string ActivityIndexTitle
        {
            get
            {
                return Localize("Atividade");
            }
        }

        /// <summary>
        /// Titulo do Create de Atividade
        /// </summary>
        public static string ActivityCreateTitle
        {
            get
            {
                return Localize("Cadastro de Atividade");
            }
        }

        /// <summary>
        /// Titulo do Edit de Atividade
        /// </summary>
        public static string ActivityEditTitle
        {
            get
            {
                return Localize("Edição de Atividade");
            }
        }

        /// <summary>
        /// Label do botão Create de Atividade
        /// </summary>
        public static string ActivityCreateButton
        {
            get
            {
                return Localize("Novo Atividade");
            }
        }

        /// <summary>
        /// Label do botão Delete de Atividade
        /// </summary>
        public static string ActivityDeleteButton
        {
            get
            {
                return Localize("Excluir Atividade");
            }
        }

        /// <summary>
        /// Titulo do index de Alert
        /// </summary>
        public static string AlertIndexTitle
        {
            get
            {
                return Localize("Alert");
            }
        }

        /// <summary>
        /// Titulo do Create de Alert
        /// </summary>
        public static string AlertCreateTitle
        {
            get
            {
                return Localize("Cadastro de Alert");
            }
        }

        /// <summary>
        /// Titulo do Edit de Alert
        /// </summary>
        public static string AlertEditTitle
        {
            get
            {
                return Localize("Edição de Alert");
            }
        }

        /// <summary>
        /// Label do botão Create de Alert
        /// </summary>
        public static string AlertCreateButton
        {
            get
            {
                return Localize("Novo Alert");
            }
        }

        /// <summary>
        /// Label do botão Delete de Alert
        /// </summary>
        public static string AlertDeleteButton
        {
            get
            {
                return Localize("Excluir Alert");
            }
        }

        /// <summary>
        /// Titulo do index de AlertArea
        /// </summary>
        public static string AlertAreaIndexTitle
        {
            get
            {
                return Localize("AlertArea");
            }
        }

        /// <summary>
        /// Titulo do Create de AlertArea
        /// </summary>
        public static string AlertAreaCreateTitle
        {
            get
            {
                return Localize("Cadastro de AlertArea");
            }
        }

        /// <summary>
        /// Titulo do Edit de AlertArea
        /// </summary>
        public static string AlertAreaEditTitle
        {
            get
            {
                return Localize("Edição de AlertArea");
            }
        }

        /// <summary>
        /// Label do botão Create de AlertArea
        /// </summary>
        public static string AlertAreaCreateButton
        {
            get
            {
                return Localize("Novo AlertArea");
            }
        }

        /// <summary>
        /// Label do botão Delete de AlertArea
        /// </summary>
        public static string AlertAreaDeleteButton
        {
            get
            {
                return Localize("Excluir AlertArea");
            }
        }

        /// <summary>
        /// Titulo do index de AlertClass
        /// </summary>
        public static string AlertClassIndexTitle
        {
            get
            {
                return Localize("AlertClass");
            }
        }

        /// <summary>
        /// Titulo do Create de AlertClass
        /// </summary>
        public static string AlertClassCreateTitle
        {
            get
            {
                return Localize("Cadastro de AlertClass");
            }
        }

        /// <summary>
        /// Titulo do Edit de AlertClass
        /// </summary>
        public static string AlertClassEditTitle
        {
            get
            {
                return Localize("Edição de AlertClass");
            }
        }

        /// <summary>
        /// Label do botão Create de AlertClass
        /// </summary>
        public static string AlertClassCreateButton
        {
            get
            {
                return Localize("Novo AlertClass");
            }
        }

        /// <summary>
        /// Label do botão Delete de AlertClass
        /// </summary>
        public static string AlertClassDeleteButton
        {
            get
            {
                return Localize("Excluir AlertClass");
            }
        }

        /// <summary>
        /// Titulo do index de AlertCommunity
        /// </summary>
        public static string AlertCommunityIndexTitle
        {
            get
            {
                return Localize("AlertCommunity");
            }
        }

        /// <summary>
        /// Titulo do Create de AlertCommunity
        /// </summary>
        public static string AlertCommunityCreateTitle
        {
            get
            {
                return Localize("Cadastro de AlertCommunity");
            }
        }

        /// <summary>
        /// Titulo do Edit de AlertCommunity
        /// </summary>
        public static string AlertCommunityEditTitle
        {
            get
            {
                return Localize("Edição de AlertCommunity");
            }
        }

        /// <summary>
        /// Label do botão Create de AlertCommunity
        /// </summary>
        public static string AlertCommunityCreateButton
        {
            get
            {
                return Localize("Novo AlertCommunity");
            }
        }

        /// <summary>
        /// Label do botão Delete de AlertCommunity
        /// </summary>
        public static string AlertCommunityDeleteButton
        {
            get
            {
                return Localize("Excluir AlertCommunity");
            }
        }

        /// <summary>
        /// Titulo do index de AlertCourse
        /// </summary>
        public static string AlertCourseIndexTitle
        {
            get
            {
                return Localize("AlertCourse");
            }
        }

        /// <summary>
        /// Titulo do Create de AlertCourse
        /// </summary>
        public static string AlertCourseCreateTitle
        {
            get
            {
                return Localize("Cadastro de AlertCourse");
            }
        }

        /// <summary>
        /// Titulo do Edit de AlertCourse
        /// </summary>
        public static string AlertCourseEditTitle
        {
            get
            {
                return Localize("Edição de AlertCourse");
            }
        }

        /// <summary>
        /// Label do botão Create de AlertCourse
        /// </summary>
        public static string AlertCourseCreateButton
        {
            get
            {
                return Localize("Novo AlertCourse");
            }
        }

        /// <summary>
        /// Label do botão Delete de AlertCourse
        /// </summary>
        public static string AlertCourseDeleteButton
        {
            get
            {
                return Localize("Excluir AlertCourse");
            }
        }

        /// <summary>
        /// Titulo do index de AlertProfile
        /// </summary>
        public static string AlertProfileIndexTitle
        {
            get
            {
                return Localize("AlertProfile");
            }
        }

        /// <summary>
        /// Titulo do Create de AlertProfile
        /// </summary>
        public static string AlertProfileCreateTitle
        {
            get
            {
                return Localize("Cadastro de AlertProfile");
            }
        }

        /// <summary>
        /// Titulo do Edit de AlertProfile
        /// </summary>
        public static string AlertProfileEditTitle
        {
            get
            {
                return Localize("Edição de AlertProfile");
            }
        }

        /// <summary>
        /// Label do botão Create de AlertProfile
        /// </summary>
        public static string AlertProfileCreateButton
        {
            get
            {
                return Localize("Novo AlertProfile");
            }
        }

        /// <summary>
        /// Label do botão Delete de AlertProfile
        /// </summary>
        public static string AlertProfileDeleteButton
        {
            get
            {
                return Localize("Excluir AlertProfile");
            }
        }

        /// <summary>
        /// Titulo do index de AlertProgram
        /// </summary>
        public static string AlertProgramIndexTitle
        {
            get
            {
                return Localize("AlertProgram");
            }
        }

        /// <summary>
        /// Titulo do Create de AlertProgram
        /// </summary>
        public static string AlertProgramCreateTitle
        {
            get
            {
                return Localize("Cadastro de AlertProgram");
            }
        }

        /// <summary>
        /// Titulo do Edit de AlertProgram
        /// </summary>
        public static string AlertProgramEditTitle
        {
            get
            {
                return Localize("Edição de AlertProgram");
            }
        }

        /// <summary>
        /// Label do botão Create de AlertProgram
        /// </summary>
        public static string AlertProgramCreateButton
        {
            get
            {
                return Localize("Novo AlertProgram");
            }
        }

        /// <summary>
        /// Label do botão Delete de AlertProgram
        /// </summary>
        public static string AlertProgramDeleteButton
        {
            get
            {
                return Localize("Excluir AlertProgram");
            }
        }

        /// <summary>
        /// Titulo do index de AlertUnit
        /// </summary>
        public static string AlertUnitIndexTitle
        {
            get
            {
                return Localize("AlertUnit");
            }
        }

        /// <summary>
        /// Titulo do Create de AlertUnit
        /// </summary>
        public static string AlertUnitCreateTitle
        {
            get
            {
                return Localize("Cadastro de AlertUnit");
            }
        }

        /// <summary>
        /// Titulo do Edit de AlertUnit
        /// </summary>
        public static string AlertUnitEditTitle
        {
            get
            {
                return Localize("Edição de AlertUnit");
            }
        }

        /// <summary>
        /// Label do botão Create de AlertUnit
        /// </summary>
        public static string AlertUnitCreateButton
        {
            get
            {
                return Localize("Novo AlertUnit");
            }
        }

        /// <summary>
        /// Label do botão Delete de AlertUnit
        /// </summary>
        public static string AlertUnitDeleteButton
        {
            get
            {
                return Localize("Excluir AlertUnit");
            }
        }

        /// <summary>
        /// Titulo do index de Appointment
        /// </summary>
        public static string AppointmentIndexTitle
        {
            get
            {
                return Localize("Appointment");
            }
        }

        /// <summary>
        /// Titulo do Create de Appointment
        /// </summary>
        public static string AppointmentCreateTitle
        {
            get
            {
                return Localize("Cadastro de Appointment");
            }
        }

        /// <summary>
        /// Titulo do Edit de Appointment
        /// </summary>
        public static string AppointmentEditTitle
        {
            get
            {
                return Localize("Edição de Appointment");
            }
        }

        /// <summary>
        /// Label do botão Create de Appointment
        /// </summary>
        public static string AppointmentCreateButton
        {
            get
            {
                return Localize("Novo Appointment");
            }
        }

        /// <summary>
        /// Label do botão Delete de Appointment
        /// </summary>
        public static string AppointmentDeleteButton
        {
            get
            {
                return Localize("Excluir Appointment");
            }
        }

        /// <summary>
        /// Titulo do index de AppointmentAppointCategory
        /// </summary>
        public static string AppointmentAppointCategoryIndexTitle
        {
            get
            {
                return Localize("AppointmentAppointCategory");
            }
        }

        /// <summary>
        /// Titulo do Create de AppointmentAppointCategory
        /// </summary>
        public static string AppointmentAppointCategoryCreateTitle
        {
            get
            {
                return Localize("Cadastro de AppointmentAppointCategory");
            }
        }

        /// <summary>
        /// Titulo do Edit de AppointmentAppointCategory
        /// </summary>
        public static string AppointmentAppointCategoryEditTitle
        {
            get
            {
                return Localize("Edição de AppointmentAppointCategory");
            }
        }

        /// <summary>
        /// Label do botão Create de AppointmentAppointCategory
        /// </summary>
        public static string AppointmentAppointCategoryCreateButton
        {
            get
            {
                return Localize("Novo AppointmentAppointCategory");
            }
        }

        /// <summary>
        /// Label do botão Delete de AppointmentAppointCategory
        /// </summary>
        public static string AppointmentAppointCategoryDeleteButton
        {
            get
            {
                return Localize("Excluir AppointmentAppointCategory");
            }
        }

        /// <summary>
        /// Titulo do index de AppointmentClass
        /// </summary>
        public static string AppointmentClassIndexTitle
        {
            get
            {
                return Localize("AppointmentClass");
            }
        }

        /// <summary>
        /// Titulo do Create de AppointmentClass
        /// </summary>
        public static string AppointmentClassCreateTitle
        {
            get
            {
                return Localize("Cadastro de AppointmentClass");
            }
        }

        /// <summary>
        /// Titulo do Edit de AppointmentClass
        /// </summary>
        public static string AppointmentClassEditTitle
        {
            get
            {
                return Localize("Edição de AppointmentClass");
            }
        }

        /// <summary>
        /// Label do botão Create de AppointmentClass
        /// </summary>
        public static string AppointmentClassCreateButton
        {
            get
            {
                return Localize("Novo AppointmentClass");
            }
        }

        /// <summary>
        /// Label do botão Delete de AppointmentClass
        /// </summary>
        public static string AppointmentClassDeleteButton
        {
            get
            {
                return Localize("Excluir AppointmentClass");
            }
        }

        /// <summary>
        /// Titulo do index de AppointmentCommunity
        /// </summary>
        public static string AppointmentCommunityIndexTitle
        {
            get
            {
                return Localize("AppointmentCommunity");
            }
        }

        /// <summary>
        /// Titulo do Create de AppointmentCommunity
        /// </summary>
        public static string AppointmentCommunityCreateTitle
        {
            get
            {
                return Localize("Cadastro de AppointmentCommunity");
            }
        }

        /// <summary>
        /// Titulo do Edit de AppointmentCommunity
        /// </summary>
        public static string AppointmentCommunityEditTitle
        {
            get
            {
                return Localize("Edição de AppointmentCommunity");
            }
        }

        /// <summary>
        /// Label do botão Create de AppointmentCommunity
        /// </summary>
        public static string AppointmentCommunityCreateButton
        {
            get
            {
                return Localize("Novo AppointmentCommunity");
            }
        }

        /// <summary>
        /// Label do botão Delete de AppointmentCommunity
        /// </summary>
        public static string AppointmentCommunityDeleteButton
        {
            get
            {
                return Localize("Excluir AppointmentCommunity");
            }
        }

        /// <summary>
        /// Titulo do index de AppointmentCourse
        /// </summary>
        public static string AppointmentCourseIndexTitle
        {
            get
            {
                return Localize("AppointmentCourse");
            }
        }

        /// <summary>
        /// Titulo do Create de AppointmentCourse
        /// </summary>
        public static string AppointmentCourseCreateTitle
        {
            get
            {
                return Localize("Cadastro de AppointmentCourse");
            }
        }

        /// <summary>
        /// Titulo do Edit de AppointmentCourse
        /// </summary>
        public static string AppointmentCourseEditTitle
        {
            get
            {
                return Localize("Edição de AppointmentCourse");
            }
        }

        /// <summary>
        /// Label do botão Create de AppointmentCourse
        /// </summary>
        public static string AppointmentCourseCreateButton
        {
            get
            {
                return Localize("Novo AppointmentCourse");
            }
        }

        /// <summary>
        /// Label do botão Delete de AppointmentCourse
        /// </summary>
        public static string AppointmentCourseDeleteButton
        {
            get
            {
                return Localize("Excluir AppointmentCourse");
            }
        }

        /// <summary>
        /// Titulo do index de AppointmentProfile
        /// </summary>
        public static string AppointmentProfileIndexTitle
        {
            get
            {
                return Localize("AppointmentProfile");
            }
        }

        /// <summary>
        /// Titulo do Create de AppointmentProfile
        /// </summary>
        public static string AppointmentProfileCreateTitle
        {
            get
            {
                return Localize("Cadastro de AppointmentProfile");
            }
        }

        /// <summary>
        /// Titulo do Edit de AppointmentProfile
        /// </summary>
        public static string AppointmentProfileEditTitle
        {
            get
            {
                return Localize("Edição de AppointmentProfile");
            }
        }

        /// <summary>
        /// Label do botão Create de AppointmentProfile
        /// </summary>
        public static string AppointmentProfileCreateButton
        {
            get
            {
                return Localize("Novo AppointmentProfile");
            }
        }

        /// <summary>
        /// Label do botão Delete de AppointmentProfile
        /// </summary>
        public static string AppointmentProfileDeleteButton
        {
            get
            {
                return Localize("Excluir AppointmentProfile");
            }
        }

        /// <summary>
        /// Titulo do index de AppointmentProgram
        /// </summary>
        public static string AppointmentProgramIndexTitle
        {
            get
            {
                return Localize("AppointmentProgram");
            }
        }

        /// <summary>
        /// Titulo do Create de AppointmentProgram
        /// </summary>
        public static string AppointmentProgramCreateTitle
        {
            get
            {
                return Localize("Cadastro de AppointmentProgram");
            }
        }

        /// <summary>
        /// Titulo do Edit de AppointmentProgram
        /// </summary>
        public static string AppointmentProgramEditTitle
        {
            get
            {
                return Localize("Edição de AppointmentProgram");
            }
        }

        /// <summary>
        /// Label do botão Create de AppointmentProgram
        /// </summary>
        public static string AppointmentProgramCreateButton
        {
            get
            {
                return Localize("Novo AppointmentProgram");
            }
        }

        /// <summary>
        /// Label do botão Delete de AppointmentProgram
        /// </summary>
        public static string AppointmentProgramDeleteButton
        {
            get
            {
                return Localize("Excluir AppointmentProgram");
            }
        }

        /// <summary>
        /// Titulo do index de AppointmentUnit
        /// </summary>
        public static string AppointmentUnitIndexTitle
        {
            get
            {
                return Localize("AppointmentUnit");
            }
        }

        /// <summary>
        /// Titulo do Create de AppointmentUnit
        /// </summary>
        public static string AppointmentUnitCreateTitle
        {
            get
            {
                return Localize("Cadastro de AppointmentUnit");
            }
        }

        /// <summary>
        /// Titulo do Edit de AppointmentUnit
        /// </summary>
        public static string AppointmentUnitEditTitle
        {
            get
            {
                return Localize("Edição de AppointmentUnit");
            }
        }

        /// <summary>
        /// Label do botão Create de AppointmentUnit
        /// </summary>
        public static string AppointmentUnitCreateButton
        {
            get
            {
                return Localize("Novo AppointmentUnit");
            }
        }

        /// <summary>
        /// Label do botão Delete de AppointmentUnit
        /// </summary>
        public static string AppointmentUnitDeleteButton
        {
            get
            {
                return Localize("Excluir AppointmentUnit");
            }
        }

        /// <summary>
        /// Titulo do index de AppointmentCategory
        /// </summary>
        public static string AppointmentCategoryIndexTitle
        {
            get
            {
                return Localize("AppointmentCategory");
            }
        }

        /// <summary>
        /// Titulo do Create de AppointmentCategory
        /// </summary>
        public static string AppointmentCategoryCreateTitle
        {
            get
            {
                return Localize("Cadastro de AppointmentCategory");
            }
        }

        /// <summary>
        /// Titulo do Edit de AppointmentCategory
        /// </summary>
        public static string AppointmentCategoryEditTitle
        {
            get
            {
                return Localize("Edição de AppointmentCategory");
            }
        }

        /// <summary>
        /// Label do botão Create de AppointmentCategory
        /// </summary>
        public static string AppointmentCategoryCreateButton
        {
            get
            {
                return Localize("Novo AppointmentCategory");
            }
        }

        /// <summary>
        /// Label do botão Delete de AppointmentCategory
        /// </summary>
        public static string AppointmentCategoryDeleteButton
        {
            get
            {
                return Localize("Excluir AppointmentCategory");
            }
        }

        /// <summary>
        /// Titulo do index de AppointmentRecurrence
        /// </summary>
        public static string AppointmentRecurrenceIndexTitle
        {
            get
            {
                return Localize("AppointmentRecurrence");
            }
        }

        /// <summary>
        /// Titulo do Create de AppointmentRecurrence
        /// </summary>
        public static string AppointmentRecurrenceCreateTitle
        {
            get
            {
                return Localize("Cadastro de AppointmentRecurrence");
            }
        }

        /// <summary>
        /// Titulo do Edit de AppointmentRecurrence
        /// </summary>
        public static string AppointmentRecurrenceEditTitle
        {
            get
            {
                return Localize("Edição de AppointmentRecurrence");
            }
        }

        /// <summary>
        /// Label do botão Create de AppointmentRecurrence
        /// </summary>
        public static string AppointmentRecurrenceCreateButton
        {
            get
            {
                return Localize("Novo AppointmentRecurrence");
            }
        }

        /// <summary>
        /// Label do botão Delete de AppointmentRecurrence
        /// </summary>
        public static string AppointmentRecurrenceDeleteButton
        {
            get
            {
                return Localize("Excluir AppointmentRecurrence");
            }
        }

        /// <summary>
        /// Titulo do index de Area
        /// </summary>
        public static string AreaIndexTitle
        {
            get
            {
                return Localize("Area");
            }
        }

        /// <summary>
        /// Titulo do Create de Area
        /// </summary>
        public static string AreaCreateTitle
        {
            get
            {
                return Localize("Cadastro de Area");
            }
        }

        /// <summary>
        /// Titulo do Edit de Area
        /// </summary>
        public static string AreaEditTitle
        {
            get
            {
                return Localize("Edição de Area");
            }
        }

        /// <summary>
        /// Label do botão Create de Area
        /// </summary>
        public static string AreaCreateButton
        {
            get
            {
                return Localize("Novo Area");
            }
        }

        /// <summary>
        /// Label do botão Delete de Area
        /// </summary>
        public static string AreaDeleteButton
        {
            get
            {
                return Localize("Excluir Area");
            }
        }

        /// <summary>
        /// Titulo do index de Avaliação
        /// </summary>
        public static string AssessmentIndexTitle
        {
            get
            {
                return Localize("Avaliação");
            }
        }

        /// <summary>
        /// Titulo do Create de Avaliação
        /// </summary>
        public static string AssessmentCreateTitle
        {
            get
            {
                return Localize("Cadastro de Avaliação");
            }
        }

        /// <summary>
        /// Titulo do Edit de Avaliação
        /// </summary>
        public static string AssessmentEditTitle
        {
            get
            {
                return Localize("Edição de Avaliação");
            }
        }

        /// <summary>
        /// Label do botão Create de Avaliação
        /// </summary>
        public static string AssessmentCreateButton
        {
            get
            {
                return Localize("Novo Avaliação");
            }
        }

        /// <summary>
        /// Label do botão Delete de Avaliação
        /// </summary>
        public static string AssessmentDeleteButton
        {
            get
            {
                return Localize("Excluir Avaliação");
            }
        }

        /// <summary>
        /// Titulo do index de AssessmentAccess
        /// </summary>
        public static string AssessmentAccessIndexTitle
        {
            get
            {
                return Localize("AssessmentAccess");
            }
        }

        /// <summary>
        /// Titulo do Create de AssessmentAccess
        /// </summary>
        public static string AssessmentAccessCreateTitle
        {
            get
            {
                return Localize("Cadastro de AssessmentAccess");
            }
        }

        /// <summary>
        /// Titulo do Edit de AssessmentAccess
        /// </summary>
        public static string AssessmentAccessEditTitle
        {
            get
            {
                return Localize("Edição de AssessmentAccess");
            }
        }

        /// <summary>
        /// Label do botão Create de AssessmentAccess
        /// </summary>
        public static string AssessmentAccessCreateButton
        {
            get
            {
                return Localize("Novo AssessmentAccess");
            }
        }

        /// <summary>
        /// Label do botão Delete de AssessmentAccess
        /// </summary>
        public static string AssessmentAccessDeleteButton
        {
            get
            {
                return Localize("Excluir AssessmentAccess");
            }
        }

        /// <summary>
        /// Titulo do index de Tentativas Avaliação
        /// </summary>
        public static string AssessmentAttemptsIndexTitle
        {
            get
            {
                return Localize("Tentativas Avaliação");
            }
        }

        /// <summary>
        /// Titulo do Create de Tentativas Avaliação
        /// </summary>
        public static string AssessmentAttemptsCreateTitle
        {
            get
            {
                return Localize("Cadastro de Tentativas Avaliação");
            }
        }

        /// <summary>
        /// Titulo do Edit de Tentativas Avaliação
        /// </summary>
        public static string AssessmentAttemptsEditTitle
        {
            get
            {
                return Localize("Edição de Tentativas Avaliação");
            }
        }

        /// <summary>
        /// Label do botão Create de Tentativas Avaliação
        /// </summary>
        public static string AssessmentAttemptsCreateButton
        {
            get
            {
                return Localize("Novo Tentativas Avaliação");
            }
        }

        /// <summary>
        /// Label do botão Delete de Tentativas Avaliação
        /// </summary>
        public static string AssessmentAttemptsDeleteButton
        {
            get
            {
                return Localize("Excluir Tentativas Avaliação");
            }
        }

        /// <summary>
        /// Titulo do index de AssessmentItemTag
        /// </summary>
        public static string AssessmentItemTagIndexTitle
        {
            get
            {
                return Localize("AssessmentItemTag");
            }
        }

        /// <summary>
        /// Titulo do Create de AssessmentItemTag
        /// </summary>
        public static string AssessmentItemTagCreateTitle
        {
            get
            {
                return Localize("Cadastro de AssessmentItemTag");
            }
        }

        /// <summary>
        /// Titulo do Edit de AssessmentItemTag
        /// </summary>
        public static string AssessmentItemTagEditTitle
        {
            get
            {
                return Localize("Edição de AssessmentItemTag");
            }
        }

        /// <summary>
        /// Label do botão Create de AssessmentItemTag
        /// </summary>
        public static string AssessmentItemTagCreateButton
        {
            get
            {
                return Localize("Novo AssessmentItemTag");
            }
        }

        /// <summary>
        /// Label do botão Delete de AssessmentItemTag
        /// </summary>
        public static string AssessmentItemTagDeleteButton
        {
            get
            {
                return Localize("Excluir AssessmentItemTag");
            }
        }

        /// <summary>
        /// Titulo do index de Questão
        /// </summary>
        public static string AssessmentQuestionIndexTitle
        {
            get
            {
                return Localize("Questão");
            }
        }

        /// <summary>
        /// Titulo do Create de Questão
        /// </summary>
        public static string AssessmentQuestionCreateTitle
        {
            get
            {
                return Localize("Cadastro de Questão");
            }
        }

        /// <summary>
        /// Titulo do Edit de Questão
        /// </summary>
        public static string AssessmentQuestionEditTitle
        {
            get
            {
                return Localize("Edição de Questão");
            }
        }

        /// <summary>
        /// Label do botão Create de Questão
        /// </summary>
        public static string AssessmentQuestionCreateButton
        {
            get
            {
                return Localize("Novo Questão");
            }
        }

        /// <summary>
        /// Label do botão Delete de Questão
        /// </summary>
        public static string AssessmentQuestionDeleteButton
        {
            get
            {
                return Localize("Excluir Questão");
            }
        }

        /// <summary>
        /// Titulo do index de Lista de Chamada
        /// </summary>
        public static string AttendanceListIndexTitle
        {
            get
            {
                return Localize("Lista de Chamada");
            }
        }

        /// <summary>
        /// Titulo do Create de Lista de Chamada
        /// </summary>
        public static string AttendanceListCreateTitle
        {
            get
            {
                return Localize("Cadastro de Lista de Chamada");
            }
        }

        /// <summary>
        /// Titulo do Edit de Lista de Chamada
        /// </summary>
        public static string AttendanceListEditTitle
        {
            get
            {
                return Localize("Edição de Lista de Chamada");
            }
        }

        /// <summary>
        /// Label do botão Create de Lista de Chamada
        /// </summary>
        public static string AttendanceListCreateButton
        {
            get
            {
                return Localize("Novo Lista de Chamada");
            }
        }

        /// <summary>
        /// Label do botão Delete de Lista de Chamada
        /// </summary>
        public static string AttendanceListDeleteButton
        {
            get
            {
                return Localize("Excluir Lista de Chamada");
            }
        }

        /// <summary>
        /// Titulo do index de Bank
        /// </summary>
        public static string BankIndexTitle
        {
            get
            {
                return Localize("Bank");
            }
        }

        /// <summary>
        /// Titulo do Create de Bank
        /// </summary>
        public static string BankCreateTitle
        {
            get
            {
                return Localize("Cadastro de Bank");
            }
        }

        /// <summary>
        /// Titulo do Edit de Bank
        /// </summary>
        public static string BankEditTitle
        {
            get
            {
                return Localize("Edição de Bank");
            }
        }

        /// <summary>
        /// Label do botão Create de Bank
        /// </summary>
        public static string BankCreateButton
        {
            get
            {
                return Localize("Novo Bank");
            }
        }

        /// <summary>
        /// Label do botão Delete de Bank
        /// </summary>
        public static string BankDeleteButton
        {
            get
            {
                return Localize("Excluir Bank");
            }
        }

        /// <summary>
        /// Titulo do index de Banner
        /// </summary>
        public static string BannerIndexTitle
        {
            get
            {
                return Localize("Banner");
            }
        }

        /// <summary>
        /// Titulo do Create de Banner
        /// </summary>
        public static string BannerCreateTitle
        {
            get
            {
                return Localize("Cadastro de Banner");
            }
        }

        /// <summary>
        /// Titulo do Edit de Banner
        /// </summary>
        public static string BannerEditTitle
        {
            get
            {
                return Localize("Edição de Banner");
            }
        }

        /// <summary>
        /// Label do botão Create de Banner
        /// </summary>
        public static string BannerCreateButton
        {
            get
            {
                return Localize("Novo Banner");
            }
        }

        /// <summary>
        /// Label do botão Delete de Banner
        /// </summary>
        public static string BannerDeleteButton
        {
            get
            {
                return Localize("Excluir Banner");
            }
        }

        /// <summary>
        /// Titulo do index de Cadastramento em Lote
        /// </summary>
        public static string BatchSetupIndexTitle
        {
            get
            {
                return Localize("Cadastramento em Lote");
            }
        }

        /// <summary>
        /// Titulo do Create de Cadastramento em Lote
        /// </summary>
        public static string BatchSetupCreateTitle
        {
            get
            {
                return Localize("Cadastro de Cadastramento em Lote");
            }
        }

        /// <summary>
        /// Titulo do Edit de Cadastramento em Lote
        /// </summary>
        public static string BatchSetupEditTitle
        {
            get
            {
                return Localize("Edição de Cadastramento em Lote");
            }
        }

        /// <summary>
        /// Label do botão Create de Cadastramento em Lote
        /// </summary>
        public static string BatchSetupCreateButton
        {
            get
            {
                return Localize("Novo Cadastramento em Lote");
            }
        }

        /// <summary>
        /// Label do botão Delete de Cadastramento em Lote
        /// </summary>
        public static string BatchSetupDeleteButton
        {
            get
            {
                return Localize("Excluir Cadastramento em Lote");
            }
        }

        /// <summary>
        /// Titulo do index de BlogPost
        /// </summary>
        public static string BlogPostIndexTitle
        {
            get
            {
                return Localize("BlogPost");
            }
        }

        /// <summary>
        /// Titulo do Create de BlogPost
        /// </summary>
        public static string BlogPostCreateTitle
        {
            get
            {
                return Localize("Cadastro de BlogPost");
            }
        }

        /// <summary>
        /// Titulo do Edit de BlogPost
        /// </summary>
        public static string BlogPostEditTitle
        {
            get
            {
                return Localize("Edição de BlogPost");
            }
        }

        /// <summary>
        /// Label do botão Create de BlogPost
        /// </summary>
        public static string BlogPostCreateButton
        {
            get
            {
                return Localize("Novo BlogPost");
            }
        }

        /// <summary>
        /// Label do botão Delete de BlogPost
        /// </summary>
        public static string BlogPostDeleteButton
        {
            get
            {
                return Localize("Excluir BlogPost");
            }
        }

        /// <summary>
        /// Titulo do index de BlogPostTag
        /// </summary>
        public static string BlogPostTagIndexTitle
        {
            get
            {
                return Localize("BlogPostTag");
            }
        }

        /// <summary>
        /// Titulo do Create de BlogPostTag
        /// </summary>
        public static string BlogPostTagCreateTitle
        {
            get
            {
                return Localize("Cadastro de BlogPostTag");
            }
        }

        /// <summary>
        /// Titulo do Edit de BlogPostTag
        /// </summary>
        public static string BlogPostTagEditTitle
        {
            get
            {
                return Localize("Edição de BlogPostTag");
            }
        }

        /// <summary>
        /// Label do botão Create de BlogPostTag
        /// </summary>
        public static string BlogPostTagCreateButton
        {
            get
            {
                return Localize("Novo BlogPostTag");
            }
        }

        /// <summary>
        /// Label do botão Delete de BlogPostTag
        /// </summary>
        public static string BlogPostTagDeleteButton
        {
            get
            {
                return Localize("Excluir BlogPostTag");
            }
        }

        /// <summary>
        /// Titulo do index de BlogPostCategory
        /// </summary>
        public static string BlogPostCategoryIndexTitle
        {
            get
            {
                return Localize("BlogPostCategory");
            }
        }

        /// <summary>
        /// Titulo do Create de BlogPostCategory
        /// </summary>
        public static string BlogPostCategoryCreateTitle
        {
            get
            {
                return Localize("Cadastro de BlogPostCategory");
            }
        }

        /// <summary>
        /// Titulo do Edit de BlogPostCategory
        /// </summary>
        public static string BlogPostCategoryEditTitle
        {
            get
            {
                return Localize("Edição de BlogPostCategory");
            }
        }

        /// <summary>
        /// Label do botão Create de BlogPostCategory
        /// </summary>
        public static string BlogPostCategoryCreateButton
        {
            get
            {
                return Localize("Novo BlogPostCategory");
            }
        }

        /// <summary>
        /// Label do botão Delete de BlogPostCategory
        /// </summary>
        public static string BlogPostCategoryDeleteButton
        {
            get
            {
                return Localize("Excluir BlogPostCategory");
            }
        }

        /// <summary>
        /// Titulo do index de BlogPostComment
        /// </summary>
        public static string BlogPostCommentIndexTitle
        {
            get
            {
                return Localize("BlogPostComment");
            }
        }

        /// <summary>
        /// Titulo do Create de BlogPostComment
        /// </summary>
        public static string BlogPostCommentCreateTitle
        {
            get
            {
                return Localize("Cadastro de BlogPostComment");
            }
        }

        /// <summary>
        /// Titulo do Edit de BlogPostComment
        /// </summary>
        public static string BlogPostCommentEditTitle
        {
            get
            {
                return Localize("Edição de BlogPostComment");
            }
        }

        /// <summary>
        /// Label do botão Create de BlogPostComment
        /// </summary>
        public static string BlogPostCommentCreateButton
        {
            get
            {
                return Localize("Novo BlogPostComment");
            }
        }

        /// <summary>
        /// Label do botão Delete de BlogPostComment
        /// </summary>
        public static string BlogPostCommentDeleteButton
        {
            get
            {
                return Localize("Excluir BlogPostComment");
            }
        }

        /// <summary>
        /// Titulo do index de Card
        /// </summary>
        public static string CardIndexTitle
        {
            get
            {
                return Localize("Card");
            }
        }

        /// <summary>
        /// Titulo do Create de Card
        /// </summary>
        public static string CardCreateTitle
        {
            get
            {
                return Localize("Cadastro de Card");
            }
        }

        /// <summary>
        /// Titulo do Edit de Card
        /// </summary>
        public static string CardEditTitle
        {
            get
            {
                return Localize("Edição de Card");
            }
        }

        /// <summary>
        /// Label do botão Create de Card
        /// </summary>
        public static string CardCreateButton
        {
            get
            {
                return Localize("Novo Card");
            }
        }

        /// <summary>
        /// Label do botão Delete de Card
        /// </summary>
        public static string CardDeleteButton
        {
            get
            {
                return Localize("Excluir Card");
            }
        }

        /// <summary>
        /// Titulo do index de CardClass
        /// </summary>
        public static string CardClassIndexTitle
        {
            get
            {
                return Localize("CardClass");
            }
        }

        /// <summary>
        /// Titulo do Create de CardClass
        /// </summary>
        public static string CardClassCreateTitle
        {
            get
            {
                return Localize("Cadastro de CardClass");
            }
        }

        /// <summary>
        /// Titulo do Edit de CardClass
        /// </summary>
        public static string CardClassEditTitle
        {
            get
            {
                return Localize("Edição de CardClass");
            }
        }

        /// <summary>
        /// Label do botão Create de CardClass
        /// </summary>
        public static string CardClassCreateButton
        {
            get
            {
                return Localize("Novo CardClass");
            }
        }

        /// <summary>
        /// Label do botão Delete de CardClass
        /// </summary>
        public static string CardClassDeleteButton
        {
            get
            {
                return Localize("Excluir CardClass");
            }
        }

        /// <summary>
        /// Titulo do index de CardCourse
        /// </summary>
        public static string CardCourseIndexTitle
        {
            get
            {
                return Localize("CardCourse");
            }
        }

        /// <summary>
        /// Titulo do Create de CardCourse
        /// </summary>
        public static string CardCourseCreateTitle
        {
            get
            {
                return Localize("Cadastro de CardCourse");
            }
        }

        /// <summary>
        /// Titulo do Edit de CardCourse
        /// </summary>
        public static string CardCourseEditTitle
        {
            get
            {
                return Localize("Edição de CardCourse");
            }
        }

        /// <summary>
        /// Label do botão Create de CardCourse
        /// </summary>
        public static string CardCourseCreateButton
        {
            get
            {
                return Localize("Novo CardCourse");
            }
        }

        /// <summary>
        /// Label do botão Delete de CardCourse
        /// </summary>
        public static string CardCourseDeleteButton
        {
            get
            {
                return Localize("Excluir CardCourse");
            }
        }

        /// <summary>
        /// Titulo do index de CardProgram
        /// </summary>
        public static string CardProgramIndexTitle
        {
            get
            {
                return Localize("CardProgram");
            }
        }

        /// <summary>
        /// Titulo do Create de CardProgram
        /// </summary>
        public static string CardProgramCreateTitle
        {
            get
            {
                return Localize("Cadastro de CardProgram");
            }
        }

        /// <summary>
        /// Titulo do Edit de CardProgram
        /// </summary>
        public static string CardProgramEditTitle
        {
            get
            {
                return Localize("Edição de CardProgram");
            }
        }

        /// <summary>
        /// Label do botão Create de CardProgram
        /// </summary>
        public static string CardProgramCreateButton
        {
            get
            {
                return Localize("Novo CardProgram");
            }
        }

        /// <summary>
        /// Label do botão Delete de CardProgram
        /// </summary>
        public static string CardProgramDeleteButton
        {
            get
            {
                return Localize("Excluir CardProgram");
            }
        }

        /// <summary>
        /// Titulo do index de Certificate
        /// </summary>
        public static string CertificateIndexTitle
        {
            get
            {
                return Localize("Certificate");
            }
        }

        /// <summary>
        /// Titulo do Create de Certificate
        /// </summary>
        public static string CertificateCreateTitle
        {
            get
            {
                return Localize("Cadastro de Certificate");
            }
        }

        /// <summary>
        /// Titulo do Edit de Certificate
        /// </summary>
        public static string CertificateEditTitle
        {
            get
            {
                return Localize("Edição de Certificate");
            }
        }

        /// <summary>
        /// Label do botão Create de Certificate
        /// </summary>
        public static string CertificateCreateButton
        {
            get
            {
                return Localize("Novo Certificate");
            }
        }

        /// <summary>
        /// Label do botão Delete de Certificate
        /// </summary>
        public static string CertificateDeleteButton
        {
            get
            {
                return Localize("Excluir Certificate");
            }
        }

        /// <summary>
        /// Titulo do index de CertificateArea
        /// </summary>
        public static string CertificateAreaIndexTitle
        {
            get
            {
                return Localize("CertificateArea");
            }
        }

        /// <summary>
        /// Titulo do Create de CertificateArea
        /// </summary>
        public static string CertificateAreaCreateTitle
        {
            get
            {
                return Localize("Cadastro de CertificateArea");
            }
        }

        /// <summary>
        /// Titulo do Edit de CertificateArea
        /// </summary>
        public static string CertificateAreaEditTitle
        {
            get
            {
                return Localize("Edição de CertificateArea");
            }
        }

        /// <summary>
        /// Label do botão Create de CertificateArea
        /// </summary>
        public static string CertificateAreaCreateButton
        {
            get
            {
                return Localize("Novo CertificateArea");
            }
        }

        /// <summary>
        /// Label do botão Delete de CertificateArea
        /// </summary>
        public static string CertificateAreaDeleteButton
        {
            get
            {
                return Localize("Excluir CertificateArea");
            }
        }

        /// <summary>
        /// Titulo do index de CertificateClass
        /// </summary>
        public static string CertificateClassIndexTitle
        {
            get
            {
                return Localize("CertificateClass");
            }
        }

        /// <summary>
        /// Titulo do Create de CertificateClass
        /// </summary>
        public static string CertificateClassCreateTitle
        {
            get
            {
                return Localize("Cadastro de CertificateClass");
            }
        }

        /// <summary>
        /// Titulo do Edit de CertificateClass
        /// </summary>
        public static string CertificateClassEditTitle
        {
            get
            {
                return Localize("Edição de CertificateClass");
            }
        }

        /// <summary>
        /// Label do botão Create de CertificateClass
        /// </summary>
        public static string CertificateClassCreateButton
        {
            get
            {
                return Localize("Novo CertificateClass");
            }
        }

        /// <summary>
        /// Label do botão Delete de CertificateClass
        /// </summary>
        public static string CertificateClassDeleteButton
        {
            get
            {
                return Localize("Excluir CertificateClass");
            }
        }

        /// <summary>
        /// Titulo do index de CertificateCommunity
        /// </summary>
        public static string CertificateCommunityIndexTitle
        {
            get
            {
                return Localize("CertificateCommunity");
            }
        }

        /// <summary>
        /// Titulo do Create de CertificateCommunity
        /// </summary>
        public static string CertificateCommunityCreateTitle
        {
            get
            {
                return Localize("Cadastro de CertificateCommunity");
            }
        }

        /// <summary>
        /// Titulo do Edit de CertificateCommunity
        /// </summary>
        public static string CertificateCommunityEditTitle
        {
            get
            {
                return Localize("Edição de CertificateCommunity");
            }
        }

        /// <summary>
        /// Label do botão Create de CertificateCommunity
        /// </summary>
        public static string CertificateCommunityCreateButton
        {
            get
            {
                return Localize("Novo CertificateCommunity");
            }
        }

        /// <summary>
        /// Label do botão Delete de CertificateCommunity
        /// </summary>
        public static string CertificateCommunityDeleteButton
        {
            get
            {
                return Localize("Excluir CertificateCommunity");
            }
        }

        /// <summary>
        /// Titulo do index de CertificateCourse
        /// </summary>
        public static string CertificateCourseIndexTitle
        {
            get
            {
                return Localize("CertificateCourse");
            }
        }

        /// <summary>
        /// Titulo do Create de CertificateCourse
        /// </summary>
        public static string CertificateCourseCreateTitle
        {
            get
            {
                return Localize("Cadastro de CertificateCourse");
            }
        }

        /// <summary>
        /// Titulo do Edit de CertificateCourse
        /// </summary>
        public static string CertificateCourseEditTitle
        {
            get
            {
                return Localize("Edição de CertificateCourse");
            }
        }

        /// <summary>
        /// Label do botão Create de CertificateCourse
        /// </summary>
        public static string CertificateCourseCreateButton
        {
            get
            {
                return Localize("Novo CertificateCourse");
            }
        }

        /// <summary>
        /// Label do botão Delete de CertificateCourse
        /// </summary>
        public static string CertificateCourseDeleteButton
        {
            get
            {
                return Localize("Excluir CertificateCourse");
            }
        }

        /// <summary>
        /// Titulo do index de CertificateProgram
        /// </summary>
        public static string CertificateProgramIndexTitle
        {
            get
            {
                return Localize("CertificateProgram");
            }
        }

        /// <summary>
        /// Titulo do Create de CertificateProgram
        /// </summary>
        public static string CertificateProgramCreateTitle
        {
            get
            {
                return Localize("Cadastro de CertificateProgram");
            }
        }

        /// <summary>
        /// Titulo do Edit de CertificateProgram
        /// </summary>
        public static string CertificateProgramEditTitle
        {
            get
            {
                return Localize("Edição de CertificateProgram");
            }
        }

        /// <summary>
        /// Label do botão Create de CertificateProgram
        /// </summary>
        public static string CertificateProgramCreateButton
        {
            get
            {
                return Localize("Novo CertificateProgram");
            }
        }

        /// <summary>
        /// Label do botão Delete de CertificateProgram
        /// </summary>
        public static string CertificateProgramDeleteButton
        {
            get
            {
                return Localize("Excluir CertificateProgram");
            }
        }

        /// <summary>
        /// Titulo do index de CertificateUnit
        /// </summary>
        public static string CertificateUnitIndexTitle
        {
            get
            {
                return Localize("CertificateUnit");
            }
        }

        /// <summary>
        /// Titulo do Create de CertificateUnit
        /// </summary>
        public static string CertificateUnitCreateTitle
        {
            get
            {
                return Localize("Cadastro de CertificateUnit");
            }
        }

        /// <summary>
        /// Titulo do Edit de CertificateUnit
        /// </summary>
        public static string CertificateUnitEditTitle
        {
            get
            {
                return Localize("Edição de CertificateUnit");
            }
        }

        /// <summary>
        /// Label do botão Create de CertificateUnit
        /// </summary>
        public static string CertificateUnitCreateButton
        {
            get
            {
                return Localize("Novo CertificateUnit");
            }
        }

        /// <summary>
        /// Label do botão Delete de CertificateUnit
        /// </summary>
        public static string CertificateUnitDeleteButton
        {
            get
            {
                return Localize("Excluir CertificateUnit");
            }
        }

        /// <summary>
        /// Titulo do index de ChangeLog
        /// </summary>
        public static string ChangeLogIndexTitle
        {
            get
            {
                return Localize("ChangeLog");
            }
        }

        /// <summary>
        /// Titulo do Create de ChangeLog
        /// </summary>
        public static string ChangeLogCreateTitle
        {
            get
            {
                return Localize("Cadastro de ChangeLog");
            }
        }

        /// <summary>
        /// Titulo do Edit de ChangeLog
        /// </summary>
        public static string ChangeLogEditTitle
        {
            get
            {
                return Localize("Edição de ChangeLog");
            }
        }

        /// <summary>
        /// Label do botão Create de ChangeLog
        /// </summary>
        public static string ChangeLogCreateButton
        {
            get
            {
                return Localize("Novo ChangeLog");
            }
        }

        /// <summary>
        /// Label do botão Delete de ChangeLog
        /// </summary>
        public static string ChangeLogDeleteButton
        {
            get
            {
                return Localize("Excluir ChangeLog");
            }
        }

        /// <summary>
        /// Titulo do index de ChatMessage
        /// </summary>
        public static string ChatMessageIndexTitle
        {
            get
            {
                return Localize("ChatMessage");
            }
        }

        /// <summary>
        /// Titulo do Create de ChatMessage
        /// </summary>
        public static string ChatMessageCreateTitle
        {
            get
            {
                return Localize("Cadastro de ChatMessage");
            }
        }

        /// <summary>
        /// Titulo do Edit de ChatMessage
        /// </summary>
        public static string ChatMessageEditTitle
        {
            get
            {
                return Localize("Edição de ChatMessage");
            }
        }

        /// <summary>
        /// Label do botão Create de ChatMessage
        /// </summary>
        public static string ChatMessageCreateButton
        {
            get
            {
                return Localize("Novo ChatMessage");
            }
        }

        /// <summary>
        /// Label do botão Delete de ChatMessage
        /// </summary>
        public static string ChatMessageDeleteButton
        {
            get
            {
                return Localize("Excluir ChatMessage");
            }
        }

        /// <summary>
        /// Titulo do index de ChatSchedule
        /// </summary>
        public static string ChatScheduleIndexTitle
        {
            get
            {
                return Localize("ChatSchedule");
            }
        }

        /// <summary>
        /// Titulo do Create de ChatSchedule
        /// </summary>
        public static string ChatScheduleCreateTitle
        {
            get
            {
                return Localize("Cadastro de ChatSchedule");
            }
        }

        /// <summary>
        /// Titulo do Edit de ChatSchedule
        /// </summary>
        public static string ChatScheduleEditTitle
        {
            get
            {
                return Localize("Edição de ChatSchedule");
            }
        }

        /// <summary>
        /// Label do botão Create de ChatSchedule
        /// </summary>
        public static string ChatScheduleCreateButton
        {
            get
            {
                return Localize("Novo ChatSchedule");
            }
        }

        /// <summary>
        /// Label do botão Delete de ChatSchedule
        /// </summary>
        public static string ChatScheduleDeleteButton
        {
            get
            {
                return Localize("Excluir ChatSchedule");
            }
        }

        /// <summary>
        /// Titulo do index de ChatScheduleClass
        /// </summary>
        public static string ChatScheduleClassIndexTitle
        {
            get
            {
                return Localize("ChatScheduleClass");
            }
        }

        /// <summary>
        /// Titulo do Create de ChatScheduleClass
        /// </summary>
        public static string ChatScheduleClassCreateTitle
        {
            get
            {
                return Localize("Cadastro de ChatScheduleClass");
            }
        }

        /// <summary>
        /// Titulo do Edit de ChatScheduleClass
        /// </summary>
        public static string ChatScheduleClassEditTitle
        {
            get
            {
                return Localize("Edição de ChatScheduleClass");
            }
        }

        /// <summary>
        /// Label do botão Create de ChatScheduleClass
        /// </summary>
        public static string ChatScheduleClassCreateButton
        {
            get
            {
                return Localize("Novo ChatScheduleClass");
            }
        }

        /// <summary>
        /// Label do botão Delete de ChatScheduleClass
        /// </summary>
        public static string ChatScheduleClassDeleteButton
        {
            get
            {
                return Localize("Excluir ChatScheduleClass");
            }
        }

        /// <summary>
        /// Titulo do index de ChatScheduleCommunity
        /// </summary>
        public static string ChatScheduleCommunityIndexTitle
        {
            get
            {
                return Localize("ChatScheduleCommunity");
            }
        }

        /// <summary>
        /// Titulo do Create de ChatScheduleCommunity
        /// </summary>
        public static string ChatScheduleCommunityCreateTitle
        {
            get
            {
                return Localize("Cadastro de ChatScheduleCommunity");
            }
        }

        /// <summary>
        /// Titulo do Edit de ChatScheduleCommunity
        /// </summary>
        public static string ChatScheduleCommunityEditTitle
        {
            get
            {
                return Localize("Edição de ChatScheduleCommunity");
            }
        }

        /// <summary>
        /// Label do botão Create de ChatScheduleCommunity
        /// </summary>
        public static string ChatScheduleCommunityCreateButton
        {
            get
            {
                return Localize("Novo ChatScheduleCommunity");
            }
        }

        /// <summary>
        /// Label do botão Delete de ChatScheduleCommunity
        /// </summary>
        public static string ChatScheduleCommunityDeleteButton
        {
            get
            {
                return Localize("Excluir ChatScheduleCommunity");
            }
        }

        /// <summary>
        /// Titulo do index de ChatScheduleCourse
        /// </summary>
        public static string ChatScheduleCourseIndexTitle
        {
            get
            {
                return Localize("ChatScheduleCourse");
            }
        }

        /// <summary>
        /// Titulo do Create de ChatScheduleCourse
        /// </summary>
        public static string ChatScheduleCourseCreateTitle
        {
            get
            {
                return Localize("Cadastro de ChatScheduleCourse");
            }
        }

        /// <summary>
        /// Titulo do Edit de ChatScheduleCourse
        /// </summary>
        public static string ChatScheduleCourseEditTitle
        {
            get
            {
                return Localize("Edição de ChatScheduleCourse");
            }
        }

        /// <summary>
        /// Label do botão Create de ChatScheduleCourse
        /// </summary>
        public static string ChatScheduleCourseCreateButton
        {
            get
            {
                return Localize("Novo ChatScheduleCourse");
            }
        }

        /// <summary>
        /// Label do botão Delete de ChatScheduleCourse
        /// </summary>
        public static string ChatScheduleCourseDeleteButton
        {
            get
            {
                return Localize("Excluir ChatScheduleCourse");
            }
        }

        /// <summary>
        /// Titulo do index de ChatScheduleProfile
        /// </summary>
        public static string ChatScheduleProfileIndexTitle
        {
            get
            {
                return Localize("ChatScheduleProfile");
            }
        }

        /// <summary>
        /// Titulo do Create de ChatScheduleProfile
        /// </summary>
        public static string ChatScheduleProfileCreateTitle
        {
            get
            {
                return Localize("Cadastro de ChatScheduleProfile");
            }
        }

        /// <summary>
        /// Titulo do Edit de ChatScheduleProfile
        /// </summary>
        public static string ChatScheduleProfileEditTitle
        {
            get
            {
                return Localize("Edição de ChatScheduleProfile");
            }
        }

        /// <summary>
        /// Label do botão Create de ChatScheduleProfile
        /// </summary>
        public static string ChatScheduleProfileCreateButton
        {
            get
            {
                return Localize("Novo ChatScheduleProfile");
            }
        }

        /// <summary>
        /// Label do botão Delete de ChatScheduleProfile
        /// </summary>
        public static string ChatScheduleProfileDeleteButton
        {
            get
            {
                return Localize("Excluir ChatScheduleProfile");
            }
        }

        /// <summary>
        /// Titulo do index de ChatScheduleProgram
        /// </summary>
        public static string ChatScheduleProgramIndexTitle
        {
            get
            {
                return Localize("ChatScheduleProgram");
            }
        }

        /// <summary>
        /// Titulo do Create de ChatScheduleProgram
        /// </summary>
        public static string ChatScheduleProgramCreateTitle
        {
            get
            {
                return Localize("Cadastro de ChatScheduleProgram");
            }
        }

        /// <summary>
        /// Titulo do Edit de ChatScheduleProgram
        /// </summary>
        public static string ChatScheduleProgramEditTitle
        {
            get
            {
                return Localize("Edição de ChatScheduleProgram");
            }
        }

        /// <summary>
        /// Label do botão Create de ChatScheduleProgram
        /// </summary>
        public static string ChatScheduleProgramCreateButton
        {
            get
            {
                return Localize("Novo ChatScheduleProgram");
            }
        }

        /// <summary>
        /// Label do botão Delete de ChatScheduleProgram
        /// </summary>
        public static string ChatScheduleProgramDeleteButton
        {
            get
            {
                return Localize("Excluir ChatScheduleProgram");
            }
        }

        /// <summary>
        /// Titulo do index de ChatScheduleUnit
        /// </summary>
        public static string ChatScheduleUnitIndexTitle
        {
            get
            {
                return Localize("ChatScheduleUnit");
            }
        }

        /// <summary>
        /// Titulo do Create de ChatScheduleUnit
        /// </summary>
        public static string ChatScheduleUnitCreateTitle
        {
            get
            {
                return Localize("Cadastro de ChatScheduleUnit");
            }
        }

        /// <summary>
        /// Titulo do Edit de ChatScheduleUnit
        /// </summary>
        public static string ChatScheduleUnitEditTitle
        {
            get
            {
                return Localize("Edição de ChatScheduleUnit");
            }
        }

        /// <summary>
        /// Label do botão Create de ChatScheduleUnit
        /// </summary>
        public static string ChatScheduleUnitCreateButton
        {
            get
            {
                return Localize("Novo ChatScheduleUnit");
            }
        }

        /// <summary>
        /// Label do botão Delete de ChatScheduleUnit
        /// </summary>
        public static string ChatScheduleUnitDeleteButton
        {
            get
            {
                return Localize("Excluir ChatScheduleUnit");
            }
        }

        /// <summary>
        /// Titulo do index de ChatScheduleUser
        /// </summary>
        public static string ChatScheduleUserIndexTitle
        {
            get
            {
                return Localize("ChatScheduleUser");
            }
        }

        /// <summary>
        /// Titulo do Create de ChatScheduleUser
        /// </summary>
        public static string ChatScheduleUserCreateTitle
        {
            get
            {
                return Localize("Cadastro de ChatScheduleUser");
            }
        }

        /// <summary>
        /// Titulo do Edit de ChatScheduleUser
        /// </summary>
        public static string ChatScheduleUserEditTitle
        {
            get
            {
                return Localize("Edição de ChatScheduleUser");
            }
        }

        /// <summary>
        /// Label do botão Create de ChatScheduleUser
        /// </summary>
        public static string ChatScheduleUserCreateButton
        {
            get
            {
                return Localize("Novo ChatScheduleUser");
            }
        }

        /// <summary>
        /// Label do botão Delete de ChatScheduleUser
        /// </summary>
        public static string ChatScheduleUserDeleteButton
        {
            get
            {
                return Localize("Excluir ChatScheduleUser");
            }
        }

        /// <summary>
        /// Titulo do index de ChatSession
        /// </summary>
        public static string ChatSessionIndexTitle
        {
            get
            {
                return Localize("ChatSession");
            }
        }

        /// <summary>
        /// Titulo do Create de ChatSession
        /// </summary>
        public static string ChatSessionCreateTitle
        {
            get
            {
                return Localize("Cadastro de ChatSession");
            }
        }

        /// <summary>
        /// Titulo do Edit de ChatSession
        /// </summary>
        public static string ChatSessionEditTitle
        {
            get
            {
                return Localize("Edição de ChatSession");
            }
        }

        /// <summary>
        /// Label do botão Create de ChatSession
        /// </summary>
        public static string ChatSessionCreateButton
        {
            get
            {
                return Localize("Novo ChatSession");
            }
        }

        /// <summary>
        /// Label do botão Delete de ChatSession
        /// </summary>
        public static string ChatSessionDeleteButton
        {
            get
            {
                return Localize("Excluir ChatSession");
            }
        }

        /// <summary>
        /// Titulo do index de ChatSessionInstance
        /// </summary>
        public static string ChatSessionInstanceIndexTitle
        {
            get
            {
                return Localize("ChatSessionInstance");
            }
        }

        /// <summary>
        /// Titulo do Create de ChatSessionInstance
        /// </summary>
        public static string ChatSessionInstanceCreateTitle
        {
            get
            {
                return Localize("Cadastro de ChatSessionInstance");
            }
        }

        /// <summary>
        /// Titulo do Edit de ChatSessionInstance
        /// </summary>
        public static string ChatSessionInstanceEditTitle
        {
            get
            {
                return Localize("Edição de ChatSessionInstance");
            }
        }

        /// <summary>
        /// Label do botão Create de ChatSessionInstance
        /// </summary>
        public static string ChatSessionInstanceCreateButton
        {
            get
            {
                return Localize("Novo ChatSessionInstance");
            }
        }

        /// <summary>
        /// Label do botão Delete de ChatSessionInstance
        /// </summary>
        public static string ChatSessionInstanceDeleteButton
        {
            get
            {
                return Localize("Excluir ChatSessionInstance");
            }
        }

        /// <summary>
        /// Titulo do index de ChatUser
        /// </summary>
        public static string ChatUserIndexTitle
        {
            get
            {
                return Localize("ChatUser");
            }
        }

        /// <summary>
        /// Titulo do Create de ChatUser
        /// </summary>
        public static string ChatUserCreateTitle
        {
            get
            {
                return Localize("Cadastro de ChatUser");
            }
        }

        /// <summary>
        /// Titulo do Edit de ChatUser
        /// </summary>
        public static string ChatUserEditTitle
        {
            get
            {
                return Localize("Edição de ChatUser");
            }
        }

        /// <summary>
        /// Label do botão Create de ChatUser
        /// </summary>
        public static string ChatUserCreateButton
        {
            get
            {
                return Localize("Novo ChatUser");
            }
        }

        /// <summary>
        /// Label do botão Delete de ChatUser
        /// </summary>
        public static string ChatUserDeleteButton
        {
            get
            {
                return Localize("Excluir ChatUser");
            }
        }

        /// <summary>
        /// Titulo do index de ChatUserInstance
        /// </summary>
        public static string ChatUserInstanceIndexTitle
        {
            get
            {
                return Localize("ChatUserInstance");
            }
        }

        /// <summary>
        /// Titulo do Create de ChatUserInstance
        /// </summary>
        public static string ChatUserInstanceCreateTitle
        {
            get
            {
                return Localize("Cadastro de ChatUserInstance");
            }
        }

        /// <summary>
        /// Titulo do Edit de ChatUserInstance
        /// </summary>
        public static string ChatUserInstanceEditTitle
        {
            get
            {
                return Localize("Edição de ChatUserInstance");
            }
        }

        /// <summary>
        /// Label do botão Create de ChatUserInstance
        /// </summary>
        public static string ChatUserInstanceCreateButton
        {
            get
            {
                return Localize("Novo ChatUserInstance");
            }
        }

        /// <summary>
        /// Label do botão Delete de ChatUserInstance
        /// </summary>
        public static string ChatUserInstanceDeleteButton
        {
            get
            {
                return Localize("Excluir ChatUserInstance");
            }
        }

        /// <summary>
        /// Titulo do index de City
        /// </summary>
        public static string CityIndexTitle
        {
            get
            {
                return Localize("City");
            }
        }

        /// <summary>
        /// Titulo do Create de City
        /// </summary>
        public static string CityCreateTitle
        {
            get
            {
                return Localize("Cadastro de City");
            }
        }

        /// <summary>
        /// Titulo do Edit de City
        /// </summary>
        public static string CityEditTitle
        {
            get
            {
                return Localize("Edição de City");
            }
        }

        /// <summary>
        /// Label do botão Create de City
        /// </summary>
        public static string CityCreateButton
        {
            get
            {
                return Localize("Novo City");
            }
        }

        /// <summary>
        /// Label do botão Delete de City
        /// </summary>
        public static string CityDeleteButton
        {
            get
            {
                return Localize("Excluir City");
            }
        }

        /// <summary>
        /// Titulo do index de Turma
        /// </summary>
        public static string ClassIndexTitle
        {
            get
            {
                return Localize("Turma");
            }
        }

        /// <summary>
        /// Titulo do Create de Turma
        /// </summary>
        public static string ClassCreateTitle
        {
            get
            {
                return Localize("Cadastro de Turma");
            }
        }

        /// <summary>
        /// Titulo do Edit de Turma
        /// </summary>
        public static string ClassEditTitle
        {
            get
            {
                return Localize("Edição de Turma");
            }
        }

        /// <summary>
        /// Label do botão Create de Turma
        /// </summary>
        public static string ClassCreateButton
        {
            get
            {
                return Localize("Novo Turma");
            }
        }

        /// <summary>
        /// Label do botão Delete de Turma
        /// </summary>
        public static string ClassDeleteButton
        {
            get
            {
                return Localize("Excluir Turma");
            }
        }

        /// <summary>
        /// Titulo do index de ClassAccess
        /// </summary>
        public static string ClassAccessIndexTitle
        {
            get
            {
                return Localize("ClassAccess");
            }
        }

        /// <summary>
        /// Titulo do Create de ClassAccess
        /// </summary>
        public static string ClassAccessCreateTitle
        {
            get
            {
                return Localize("Cadastro de ClassAccess");
            }
        }

        /// <summary>
        /// Titulo do Edit de ClassAccess
        /// </summary>
        public static string ClassAccessEditTitle
        {
            get
            {
                return Localize("Edição de ClassAccess");
            }
        }

        /// <summary>
        /// Label do botão Create de ClassAccess
        /// </summary>
        public static string ClassAccessCreateButton
        {
            get
            {
                return Localize("Novo ClassAccess");
            }
        }

        /// <summary>
        /// Label do botão Delete de ClassAccess
        /// </summary>
        public static string ClassAccessDeleteButton
        {
            get
            {
                return Localize("Excluir ClassAccess");
            }
        }

        /// <summary>
        /// Titulo do index de ClassTutor
        /// </summary>
        public static string ClassTutorIndexTitle
        {
            get
            {
                return Localize("ClassTutor");
            }
        }

        /// <summary>
        /// Titulo do Create de ClassTutor
        /// </summary>
        public static string ClassTutorCreateTitle
        {
            get
            {
                return Localize("Cadastro de ClassTutor");
            }
        }

        /// <summary>
        /// Titulo do Edit de ClassTutor
        /// </summary>
        public static string ClassTutorEditTitle
        {
            get
            {
                return Localize("Edição de ClassTutor");
            }
        }

        /// <summary>
        /// Label do botão Create de ClassTutor
        /// </summary>
        public static string ClassTutorCreateButton
        {
            get
            {
                return Localize("Novo ClassTutor");
            }
        }

        /// <summary>
        /// Label do botão Delete de ClassTutor
        /// </summary>
        public static string ClassTutorDeleteButton
        {
            get
            {
                return Localize("Excluir ClassTutor");
            }
        }

        /// <summary>
        /// Titulo do index de Turma Disponibilidade
        /// </summary>
        public static string ClassAvailabilityIndexTitle
        {
            get
            {
                return Localize("Turma Disponibilidade");
            }
        }

        /// <summary>
        /// Titulo do Create de Turma Disponibilidade
        /// </summary>
        public static string ClassAvailabilityCreateTitle
        {
            get
            {
                return Localize("Cadastro de Turma Disponibilidade");
            }
        }

        /// <summary>
        /// Titulo do Edit de Turma Disponibilidade
        /// </summary>
        public static string ClassAvailabilityEditTitle
        {
            get
            {
                return Localize("Edição de Turma Disponibilidade");
            }
        }

        /// <summary>
        /// Label do botão Create de Turma Disponibilidade
        /// </summary>
        public static string ClassAvailabilityCreateButton
        {
            get
            {
                return Localize("Novo Turma Disponibilidade");
            }
        }

        /// <summary>
        /// Label do botão Delete de Turma Disponibilidade
        /// </summary>
        public static string ClassAvailabilityDeleteButton
        {
            get
            {
                return Localize("Excluir Turma Disponibilidade");
            }
        }

        /// <summary>
        /// Titulo do index de Custo Aula Recurso
        /// </summary>
        public static string ClassResourcesCostIndexTitle
        {
            get
            {
                return Localize("Custo Aula Recurso");
            }
        }

        /// <summary>
        /// Titulo do Create de Custo Aula Recurso
        /// </summary>
        public static string ClassResourcesCostCreateTitle
        {
            get
            {
                return Localize("Cadastro de Custo Aula Recurso");
            }
        }

        /// <summary>
        /// Titulo do Edit de Custo Aula Recurso
        /// </summary>
        public static string ClassResourcesCostEditTitle
        {
            get
            {
                return Localize("Edição de Custo Aula Recurso");
            }
        }

        /// <summary>
        /// Label do botão Create de Custo Aula Recurso
        /// </summary>
        public static string ClassResourcesCostCreateButton
        {
            get
            {
                return Localize("Novo Custo Aula Recurso");
            }
        }

        /// <summary>
        /// Label do botão Delete de Custo Aula Recurso
        /// </summary>
        public static string ClassResourcesCostDeleteButton
        {
            get
            {
                return Localize("Excluir Custo Aula Recurso");
            }
        }

        /// <summary>
        /// Titulo do index de Sala de Aula
        /// </summary>
        public static string ClassroomIndexTitle
        {
            get
            {
                return Localize("Sala de Aula");
            }
        }

        /// <summary>
        /// Titulo do Create de Sala de Aula
        /// </summary>
        public static string ClassroomCreateTitle
        {
            get
            {
                return Localize("Cadastro de Sala de Aula");
            }
        }

        /// <summary>
        /// Titulo do Edit de Sala de Aula
        /// </summary>
        public static string ClassroomEditTitle
        {
            get
            {
                return Localize("Edição de Sala de Aula");
            }
        }

        /// <summary>
        /// Label do botão Create de Sala de Aula
        /// </summary>
        public static string ClassroomCreateButton
        {
            get
            {
                return Localize("Novo Sala de Aula");
            }
        }

        /// <summary>
        /// Label do botão Delete de Sala de Aula
        /// </summary>
        public static string ClassroomDeleteButton
        {
            get
            {
                return Localize("Excluir Sala de Aula");
            }
        }

        /// <summary>
        /// Titulo do index de ClassroomClassroomResources
        /// </summary>
        public static string ClassroomClassroomResourcesIndexTitle
        {
            get
            {
                return Localize("ClassroomClassroomResources");
            }
        }

        /// <summary>
        /// Titulo do Create de ClassroomClassroomResources
        /// </summary>
        public static string ClassroomClassroomResourcesCreateTitle
        {
            get
            {
                return Localize("Cadastro de ClassroomClassroomResources");
            }
        }

        /// <summary>
        /// Titulo do Edit de ClassroomClassroomResources
        /// </summary>
        public static string ClassroomClassroomResourcesEditTitle
        {
            get
            {
                return Localize("Edição de ClassroomClassroomResources");
            }
        }

        /// <summary>
        /// Label do botão Create de ClassroomClassroomResources
        /// </summary>
        public static string ClassroomClassroomResourcesCreateButton
        {
            get
            {
                return Localize("Novo ClassroomClassroomResources");
            }
        }

        /// <summary>
        /// Label do botão Delete de ClassroomClassroomResources
        /// </summary>
        public static string ClassroomClassroomResourcesDeleteButton
        {
            get
            {
                return Localize("Excluir ClassroomClassroomResources");
            }
        }

        /// <summary>
        /// Titulo do index de Recursos Sala de Aula
        /// </summary>
        public static string ClassroomResourcesIndexTitle
        {
            get
            {
                return Localize("Recursos Sala de Aula");
            }
        }

        /// <summary>
        /// Titulo do Create de Recursos Sala de Aula
        /// </summary>
        public static string ClassroomResourcesCreateTitle
        {
            get
            {
                return Localize("Cadastro de Recursos Sala de Aula");
            }
        }

        /// <summary>
        /// Titulo do Edit de Recursos Sala de Aula
        /// </summary>
        public static string ClassroomResourcesEditTitle
        {
            get
            {
                return Localize("Edição de Recursos Sala de Aula");
            }
        }

        /// <summary>
        /// Label do botão Create de Recursos Sala de Aula
        /// </summary>
        public static string ClassroomResourcesCreateButton
        {
            get
            {
                return Localize("Novo Recursos Sala de Aula");
            }
        }

        /// <summary>
        /// Label do botão Delete de Recursos Sala de Aula
        /// </summary>
        public static string ClassroomResourcesDeleteButton
        {
            get
            {
                return Localize("Excluir Recursos Sala de Aula");
            }
        }

        /// <summary>
        /// Titulo do index de Categoria Recursos Sala de Aula
        /// </summary>
        public static string ClassroomResourcesCategoryIndexTitle
        {
            get
            {
                return Localize("Categoria Recursos Sala de Aula");
            }
        }

        /// <summary>
        /// Titulo do Create de Categoria Recursos Sala de Aula
        /// </summary>
        public static string ClassroomResourcesCategoryCreateTitle
        {
            get
            {
                return Localize("Cadastro de Categoria Recursos Sala de Aula");
            }
        }

        /// <summary>
        /// Titulo do Edit de Categoria Recursos Sala de Aula
        /// </summary>
        public static string ClassroomResourcesCategoryEditTitle
        {
            get
            {
                return Localize("Edição de Categoria Recursos Sala de Aula");
            }
        }

        /// <summary>
        /// Label do botão Create de Categoria Recursos Sala de Aula
        /// </summary>
        public static string ClassroomResourcesCategoryCreateButton
        {
            get
            {
                return Localize("Novo Categoria Recursos Sala de Aula");
            }
        }

        /// <summary>
        /// Label do botão Delete de Categoria Recursos Sala de Aula
        /// </summary>
        public static string ClassroomResourcesCategoryDeleteButton
        {
            get
            {
                return Localize("Excluir Categoria Recursos Sala de Aula");
            }
        }

        /// <summary>
        /// Titulo do index de Custo Aula Tutor
        /// </summary>
        public static string ClassTutorCostIndexTitle
        {
            get
            {
                return Localize("Custo Aula Tutor");
            }
        }

        /// <summary>
        /// Titulo do Create de Custo Aula Tutor
        /// </summary>
        public static string ClassTutorCostCreateTitle
        {
            get
            {
                return Localize("Cadastro de Custo Aula Tutor");
            }
        }

        /// <summary>
        /// Titulo do Edit de Custo Aula Tutor
        /// </summary>
        public static string ClassTutorCostEditTitle
        {
            get
            {
                return Localize("Edição de Custo Aula Tutor");
            }
        }

        /// <summary>
        /// Label do botão Create de Custo Aula Tutor
        /// </summary>
        public static string ClassTutorCostCreateButton
        {
            get
            {
                return Localize("Novo Custo Aula Tutor");
            }
        }

        /// <summary>
        /// Label do botão Delete de Custo Aula Tutor
        /// </summary>
        public static string ClassTutorCostDeleteButton
        {
            get
            {
                return Localize("Excluir Custo Aula Tutor");
            }
        }

        /// <summary>
        /// Titulo do index de Questão Fechada
        /// </summary>
        public static string ClosedQuestionIndexTitle
        {
            get
            {
                return Localize("Questão Fechada");
            }
        }

        /// <summary>
        /// Titulo do Create de Questão Fechada
        /// </summary>
        public static string ClosedQuestionCreateTitle
        {
            get
            {
                return Localize("Cadastro de Questão Fechada");
            }
        }

        /// <summary>
        /// Titulo do Edit de Questão Fechada
        /// </summary>
        public static string ClosedQuestionEditTitle
        {
            get
            {
                return Localize("Edição de Questão Fechada");
            }
        }

        /// <summary>
        /// Label do botão Create de Questão Fechada
        /// </summary>
        public static string ClosedQuestionCreateButton
        {
            get
            {
                return Localize("Novo Questão Fechada");
            }
        }

        /// <summary>
        /// Label do botão Delete de Questão Fechada
        /// </summary>
        public static string ClosedQuestionDeleteButton
        {
            get
            {
                return Localize("Excluir Questão Fechada");
            }
        }

        /// <summary>
        /// Titulo do index de Community
        /// </summary>
        public static string CommunityIndexTitle
        {
            get
            {
                return Localize("Community");
            }
        }

        /// <summary>
        /// Titulo do Create de Community
        /// </summary>
        public static string CommunityCreateTitle
        {
            get
            {
                return Localize("Cadastro de Community");
            }
        }

        /// <summary>
        /// Titulo do Edit de Community
        /// </summary>
        public static string CommunityEditTitle
        {
            get
            {
                return Localize("Edição de Community");
            }
        }

        /// <summary>
        /// Label do botão Create de Community
        /// </summary>
        public static string CommunityCreateButton
        {
            get
            {
                return Localize("Novo Community");
            }
        }

        /// <summary>
        /// Label do botão Delete de Community
        /// </summary>
        public static string CommunityDeleteButton
        {
            get
            {
                return Localize("Excluir Community");
            }
        }

        /// <summary>
        /// Titulo do index de CommunityClass
        /// </summary>
        public static string CommunityClassIndexTitle
        {
            get
            {
                return Localize("CommunityClass");
            }
        }

        /// <summary>
        /// Titulo do Create de CommunityClass
        /// </summary>
        public static string CommunityClassCreateTitle
        {
            get
            {
                return Localize("Cadastro de CommunityClass");
            }
        }

        /// <summary>
        /// Titulo do Edit de CommunityClass
        /// </summary>
        public static string CommunityClassEditTitle
        {
            get
            {
                return Localize("Edição de CommunityClass");
            }
        }

        /// <summary>
        /// Label do botão Create de CommunityClass
        /// </summary>
        public static string CommunityClassCreateButton
        {
            get
            {
                return Localize("Novo CommunityClass");
            }
        }

        /// <summary>
        /// Label do botão Delete de CommunityClass
        /// </summary>
        public static string CommunityClassDeleteButton
        {
            get
            {
                return Localize("Excluir CommunityClass");
            }
        }

        /// <summary>
        /// Titulo do index de CommunityCourse
        /// </summary>
        public static string CommunityCourseIndexTitle
        {
            get
            {
                return Localize("CommunityCourse");
            }
        }

        /// <summary>
        /// Titulo do Create de CommunityCourse
        /// </summary>
        public static string CommunityCourseCreateTitle
        {
            get
            {
                return Localize("Cadastro de CommunityCourse");
            }
        }

        /// <summary>
        /// Titulo do Edit de CommunityCourse
        /// </summary>
        public static string CommunityCourseEditTitle
        {
            get
            {
                return Localize("Edição de CommunityCourse");
            }
        }

        /// <summary>
        /// Label do botão Create de CommunityCourse
        /// </summary>
        public static string CommunityCourseCreateButton
        {
            get
            {
                return Localize("Novo CommunityCourse");
            }
        }

        /// <summary>
        /// Label do botão Delete de CommunityCourse
        /// </summary>
        public static string CommunityCourseDeleteButton
        {
            get
            {
                return Localize("Excluir CommunityCourse");
            }
        }

        /// <summary>
        /// Titulo do index de CommunityTag
        /// </summary>
        public static string CommunityTagIndexTitle
        {
            get
            {
                return Localize("CommunityTag");
            }
        }

        /// <summary>
        /// Titulo do Create de CommunityTag
        /// </summary>
        public static string CommunityTagCreateTitle
        {
            get
            {
                return Localize("Cadastro de CommunityTag");
            }
        }

        /// <summary>
        /// Titulo do Edit de CommunityTag
        /// </summary>
        public static string CommunityTagEditTitle
        {
            get
            {
                return Localize("Edição de CommunityTag");
            }
        }

        /// <summary>
        /// Label do botão Create de CommunityTag
        /// </summary>
        public static string CommunityTagCreateButton
        {
            get
            {
                return Localize("Novo CommunityTag");
            }
        }

        /// <summary>
        /// Label do botão Delete de CommunityTag
        /// </summary>
        public static string CommunityTagDeleteButton
        {
            get
            {
                return Localize("Excluir CommunityTag");
            }
        }

        /// <summary>
        /// Titulo do index de CommunityUnit
        /// </summary>
        public static string CommunityUnitIndexTitle
        {
            get
            {
                return Localize("CommunityUnit");
            }
        }

        /// <summary>
        /// Titulo do Create de CommunityUnit
        /// </summary>
        public static string CommunityUnitCreateTitle
        {
            get
            {
                return Localize("Cadastro de CommunityUnit");
            }
        }

        /// <summary>
        /// Titulo do Edit de CommunityUnit
        /// </summary>
        public static string CommunityUnitEditTitle
        {
            get
            {
                return Localize("Edição de CommunityUnit");
            }
        }

        /// <summary>
        /// Label do botão Create de CommunityUnit
        /// </summary>
        public static string CommunityUnitCreateButton
        {
            get
            {
                return Localize("Novo CommunityUnit");
            }
        }

        /// <summary>
        /// Label do botão Delete de CommunityUnit
        /// </summary>
        public static string CommunityUnitDeleteButton
        {
            get
            {
                return Localize("Excluir CommunityUnit");
            }
        }

        /// <summary>
        /// Titulo do index de CommunityCategory
        /// </summary>
        public static string CommunityCategoryIndexTitle
        {
            get
            {
                return Localize("CommunityCategory");
            }
        }

        /// <summary>
        /// Titulo do Create de CommunityCategory
        /// </summary>
        public static string CommunityCategoryCreateTitle
        {
            get
            {
                return Localize("Cadastro de CommunityCategory");
            }
        }

        /// <summary>
        /// Titulo do Edit de CommunityCategory
        /// </summary>
        public static string CommunityCategoryEditTitle
        {
            get
            {
                return Localize("Edição de CommunityCategory");
            }
        }

        /// <summary>
        /// Label do botão Create de CommunityCategory
        /// </summary>
        public static string CommunityCategoryCreateButton
        {
            get
            {
                return Localize("Novo CommunityCategory");
            }
        }

        /// <summary>
        /// Label do botão Delete de CommunityCategory
        /// </summary>
        public static string CommunityCategoryDeleteButton
        {
            get
            {
                return Localize("Excluir CommunityCategory");
            }
        }

        /// <summary>
        /// Titulo do index de CommunityComment
        /// </summary>
        public static string CommunityCommentIndexTitle
        {
            get
            {
                return Localize("CommunityComment");
            }
        }

        /// <summary>
        /// Titulo do Create de CommunityComment
        /// </summary>
        public static string CommunityCommentCreateTitle
        {
            get
            {
                return Localize("Cadastro de CommunityComment");
            }
        }

        /// <summary>
        /// Titulo do Edit de CommunityComment
        /// </summary>
        public static string CommunityCommentEditTitle
        {
            get
            {
                return Localize("Edição de CommunityComment");
            }
        }

        /// <summary>
        /// Label do botão Create de CommunityComment
        /// </summary>
        public static string CommunityCommentCreateButton
        {
            get
            {
                return Localize("Novo CommunityComment");
            }
        }

        /// <summary>
        /// Label do botão Delete de CommunityComment
        /// </summary>
        public static string CommunityCommentDeleteButton
        {
            get
            {
                return Localize("Excluir CommunityComment");
            }
        }

        /// <summary>
        /// Titulo do index de CommunityPermission
        /// </summary>
        public static string CommunityPermissionIndexTitle
        {
            get
            {
                return Localize("CommunityPermission");
            }
        }

        /// <summary>
        /// Titulo do Create de CommunityPermission
        /// </summary>
        public static string CommunityPermissionCreateTitle
        {
            get
            {
                return Localize("Cadastro de CommunityPermission");
            }
        }

        /// <summary>
        /// Titulo do Edit de CommunityPermission
        /// </summary>
        public static string CommunityPermissionEditTitle
        {
            get
            {
                return Localize("Edição de CommunityPermission");
            }
        }

        /// <summary>
        /// Label do botão Create de CommunityPermission
        /// </summary>
        public static string CommunityPermissionCreateButton
        {
            get
            {
                return Localize("Novo CommunityPermission");
            }
        }

        /// <summary>
        /// Label do botão Delete de CommunityPermission
        /// </summary>
        public static string CommunityPermissionDeleteButton
        {
            get
            {
                return Localize("Excluir CommunityPermission");
            }
        }

        /// <summary>
        /// Titulo do index de Component
        /// </summary>
        public static string ComponentIndexTitle
        {
            get
            {
                return Localize("Component");
            }
        }

        /// <summary>
        /// Titulo do Create de Component
        /// </summary>
        public static string ComponentCreateTitle
        {
            get
            {
                return Localize("Cadastro de Component");
            }
        }

        /// <summary>
        /// Titulo do Edit de Component
        /// </summary>
        public static string ComponentEditTitle
        {
            get
            {
                return Localize("Edição de Component");
            }
        }

        /// <summary>
        /// Label do botão Create de Component
        /// </summary>
        public static string ComponentCreateButton
        {
            get
            {
                return Localize("Novo Component");
            }
        }

        /// <summary>
        /// Label do botão Delete de Component
        /// </summary>
        public static string ComponentDeleteButton
        {
            get
            {
                return Localize("Excluir Component");
            }
        }

        /// <summary>
        /// Titulo do index de ConferenceEvent
        /// </summary>
        public static string ConferenceEventIndexTitle
        {
            get
            {
                return Localize("ConferenceEvent");
            }
        }

        /// <summary>
        /// Titulo do Create de ConferenceEvent
        /// </summary>
        public static string ConferenceEventCreateTitle
        {
            get
            {
                return Localize("Cadastro de ConferenceEvent");
            }
        }

        /// <summary>
        /// Titulo do Edit de ConferenceEvent
        /// </summary>
        public static string ConferenceEventEditTitle
        {
            get
            {
                return Localize("Edição de ConferenceEvent");
            }
        }

        /// <summary>
        /// Label do botão Create de ConferenceEvent
        /// </summary>
        public static string ConferenceEventCreateButton
        {
            get
            {
                return Localize("Novo ConferenceEvent");
            }
        }

        /// <summary>
        /// Label do botão Delete de ConferenceEvent
        /// </summary>
        public static string ConferenceEventDeleteButton
        {
            get
            {
                return Localize("Excluir ConferenceEvent");
            }
        }

        /// <summary>
        /// Titulo do index de ConferenceEventClass
        /// </summary>
        public static string ConferenceEventClassIndexTitle
        {
            get
            {
                return Localize("ConferenceEventClass");
            }
        }

        /// <summary>
        /// Titulo do Create de ConferenceEventClass
        /// </summary>
        public static string ConferenceEventClassCreateTitle
        {
            get
            {
                return Localize("Cadastro de ConferenceEventClass");
            }
        }

        /// <summary>
        /// Titulo do Edit de ConferenceEventClass
        /// </summary>
        public static string ConferenceEventClassEditTitle
        {
            get
            {
                return Localize("Edição de ConferenceEventClass");
            }
        }

        /// <summary>
        /// Label do botão Create de ConferenceEventClass
        /// </summary>
        public static string ConferenceEventClassCreateButton
        {
            get
            {
                return Localize("Novo ConferenceEventClass");
            }
        }

        /// <summary>
        /// Label do botão Delete de ConferenceEventClass
        /// </summary>
        public static string ConferenceEventClassDeleteButton
        {
            get
            {
                return Localize("Excluir ConferenceEventClass");
            }
        }

        /// <summary>
        /// Titulo do index de ConferenceEventCommunity
        /// </summary>
        public static string ConferenceEventCommunityIndexTitle
        {
            get
            {
                return Localize("ConferenceEventCommunity");
            }
        }

        /// <summary>
        /// Titulo do Create de ConferenceEventCommunity
        /// </summary>
        public static string ConferenceEventCommunityCreateTitle
        {
            get
            {
                return Localize("Cadastro de ConferenceEventCommunity");
            }
        }

        /// <summary>
        /// Titulo do Edit de ConferenceEventCommunity
        /// </summary>
        public static string ConferenceEventCommunityEditTitle
        {
            get
            {
                return Localize("Edição de ConferenceEventCommunity");
            }
        }

        /// <summary>
        /// Label do botão Create de ConferenceEventCommunity
        /// </summary>
        public static string ConferenceEventCommunityCreateButton
        {
            get
            {
                return Localize("Novo ConferenceEventCommunity");
            }
        }

        /// <summary>
        /// Label do botão Delete de ConferenceEventCommunity
        /// </summary>
        public static string ConferenceEventCommunityDeleteButton
        {
            get
            {
                return Localize("Excluir ConferenceEventCommunity");
            }
        }

        /// <summary>
        /// Titulo do index de ConferenceEventUser
        /// </summary>
        public static string ConferenceEventUserIndexTitle
        {
            get
            {
                return Localize("ConferenceEventUser");
            }
        }

        /// <summary>
        /// Titulo do Create de ConferenceEventUser
        /// </summary>
        public static string ConferenceEventUserCreateTitle
        {
            get
            {
                return Localize("Cadastro de ConferenceEventUser");
            }
        }

        /// <summary>
        /// Titulo do Edit de ConferenceEventUser
        /// </summary>
        public static string ConferenceEventUserEditTitle
        {
            get
            {
                return Localize("Edição de ConferenceEventUser");
            }
        }

        /// <summary>
        /// Label do botão Create de ConferenceEventUser
        /// </summary>
        public static string ConferenceEventUserCreateButton
        {
            get
            {
                return Localize("Novo ConferenceEventUser");
            }
        }

        /// <summary>
        /// Label do botão Delete de ConferenceEventUser
        /// </summary>
        public static string ConferenceEventUserDeleteButton
        {
            get
            {
                return Localize("Excluir ConferenceEventUser");
            }
        }

        /// <summary>
        /// Titulo do index de Contact
        /// </summary>
        public static string ContactIndexTitle
        {
            get
            {
                return Localize("Contact");
            }
        }

        /// <summary>
        /// Titulo do Create de Contact
        /// </summary>
        public static string ContactCreateTitle
        {
            get
            {
                return Localize("Cadastro de Contact");
            }
        }

        /// <summary>
        /// Titulo do Edit de Contact
        /// </summary>
        public static string ContactEditTitle
        {
            get
            {
                return Localize("Edição de Contact");
            }
        }

        /// <summary>
        /// Label do botão Create de Contact
        /// </summary>
        public static string ContactCreateButton
        {
            get
            {
                return Localize("Novo Contact");
            }
        }

        /// <summary>
        /// Label do botão Delete de Contact
        /// </summary>
        public static string ContactDeleteButton
        {
            get
            {
                return Localize("Excluir Contact");
            }
        }

        /// <summary>
        /// Titulo do index de ContactServiceProvider
        /// </summary>
        public static string ContactServiceProviderIndexTitle
        {
            get
            {
                return Localize("ContactServiceProvider");
            }
        }

        /// <summary>
        /// Titulo do Create de ContactServiceProvider
        /// </summary>
        public static string ContactServiceProviderCreateTitle
        {
            get
            {
                return Localize("Cadastro de ContactServiceProvider");
            }
        }

        /// <summary>
        /// Titulo do Edit de ContactServiceProvider
        /// </summary>
        public static string ContactServiceProviderEditTitle
        {
            get
            {
                return Localize("Edição de ContactServiceProvider");
            }
        }

        /// <summary>
        /// Label do botão Create de ContactServiceProvider
        /// </summary>
        public static string ContactServiceProviderCreateButton
        {
            get
            {
                return Localize("Novo ContactServiceProvider");
            }
        }

        /// <summary>
        /// Label do botão Delete de ContactServiceProvider
        /// </summary>
        public static string ContactServiceProviderDeleteButton
        {
            get
            {
                return Localize("Excluir ContactServiceProvider");
            }
        }

        /// <summary>
        /// Titulo do index de Coordenação
        /// </summary>
        public static string CoordenationIndexTitle
        {
            get
            {
                return Localize("Coordenação");
            }
        }

        /// <summary>
        /// Titulo do Create de Coordenação
        /// </summary>
        public static string CoordenationCreateTitle
        {
            get
            {
                return Localize("Cadastro de Coordenação");
            }
        }

        /// <summary>
        /// Titulo do Edit de Coordenação
        /// </summary>
        public static string CoordenationEditTitle
        {
            get
            {
                return Localize("Edição de Coordenação");
            }
        }

        /// <summary>
        /// Label do botão Create de Coordenação
        /// </summary>
        public static string CoordenationCreateButton
        {
            get
            {
                return Localize("Novo Coordenação");
            }
        }

        /// <summary>
        /// Label do botão Delete de Coordenação
        /// </summary>
        public static string CoordenationDeleteButton
        {
            get
            {
                return Localize("Excluir Coordenação");
            }
        }

        /// <summary>
        /// Titulo do index de Country
        /// </summary>
        public static string CountryIndexTitle
        {
            get
            {
                return Localize("Country");
            }
        }

        /// <summary>
        /// Titulo do Create de Country
        /// </summary>
        public static string CountryCreateTitle
        {
            get
            {
                return Localize("Cadastro de Country");
            }
        }

        /// <summary>
        /// Titulo do Edit de Country
        /// </summary>
        public static string CountryEditTitle
        {
            get
            {
                return Localize("Edição de Country");
            }
        }

        /// <summary>
        /// Label do botão Create de Country
        /// </summary>
        public static string CountryCreateButton
        {
            get
            {
                return Localize("Novo Country");
            }
        }

        /// <summary>
        /// Label do botão Delete de Country
        /// </summary>
        public static string CountryDeleteButton
        {
            get
            {
                return Localize("Excluir Country");
            }
        }

        /// <summary>
        /// Titulo do index de Curso
        /// </summary>
        public static string CourseIndexTitle
        {
            get
            {
                return Localize("Curso");
            }
        }

        /// <summary>
        /// Titulo do Create de Curso
        /// </summary>
        public static string CourseCreateTitle
        {
            get
            {
                return Localize("Cadastro de Curso");
            }
        }

        /// <summary>
        /// Titulo do Edit de Curso
        /// </summary>
        public static string CourseEditTitle
        {
            get
            {
                return Localize("Edição de Curso");
            }
        }

        /// <summary>
        /// Label do botão Create de Curso
        /// </summary>
        public static string CourseCreateButton
        {
            get
            {
                return Localize("Novo Curso");
            }
        }

        /// <summary>
        /// Label do botão Delete de Curso
        /// </summary>
        public static string CourseDeleteButton
        {
            get
            {
                return Localize("Excluir Curso");
            }
        }

        /// <summary>
        /// Titulo do index de CourseFeatures
        /// </summary>
        public static string CourseFeaturesIndexTitle
        {
            get
            {
                return Localize("CourseFeatures");
            }
        }

        /// <summary>
        /// Titulo do Create de CourseFeatures
        /// </summary>
        public static string CourseFeaturesCreateTitle
        {
            get
            {
                return Localize("Cadastro de CourseFeatures");
            }
        }

        /// <summary>
        /// Titulo do Edit de CourseFeatures
        /// </summary>
        public static string CourseFeaturesEditTitle
        {
            get
            {
                return Localize("Edição de CourseFeatures");
            }
        }

        /// <summary>
        /// Label do botão Create de CourseFeatures
        /// </summary>
        public static string CourseFeaturesCreateButton
        {
            get
            {
                return Localize("Novo CourseFeatures");
            }
        }

        /// <summary>
        /// Label do botão Delete de CourseFeatures
        /// </summary>
        public static string CourseFeaturesDeleteButton
        {
            get
            {
                return Localize("Excluir CourseFeatures");
            }
        }

        /// <summary>
        /// Titulo do index de CourseFeaturesResumeCourse
        /// </summary>
        public static string CourseFeaturesResumeCourseIndexTitle
        {
            get
            {
                return Localize("CourseFeaturesResumeCourse");
            }
        }

        /// <summary>
        /// Titulo do Create de CourseFeaturesResumeCourse
        /// </summary>
        public static string CourseFeaturesResumeCourseCreateTitle
        {
            get
            {
                return Localize("Cadastro de CourseFeaturesResumeCourse");
            }
        }

        /// <summary>
        /// Titulo do Edit de CourseFeaturesResumeCourse
        /// </summary>
        public static string CourseFeaturesResumeCourseEditTitle
        {
            get
            {
                return Localize("Edição de CourseFeaturesResumeCourse");
            }
        }

        /// <summary>
        /// Label do botão Create de CourseFeaturesResumeCourse
        /// </summary>
        public static string CourseFeaturesResumeCourseCreateButton
        {
            get
            {
                return Localize("Novo CourseFeaturesResumeCourse");
            }
        }

        /// <summary>
        /// Label do botão Delete de CourseFeaturesResumeCourse
        /// </summary>
        public static string CourseFeaturesResumeCourseDeleteButton
        {
            get
            {
                return Localize("Excluir CourseFeaturesResumeCourse");
            }
        }

        /// <summary>
        /// Titulo do index de Grupo de Curso
        /// </summary>
        public static string CourseGroupIndexTitle
        {
            get
            {
                return Localize("Grupo de Curso");
            }
        }

        /// <summary>
        /// Titulo do Create de Grupo de Curso
        /// </summary>
        public static string CourseGroupCreateTitle
        {
            get
            {
                return Localize("Cadastro de Grupo de Curso");
            }
        }

        /// <summary>
        /// Titulo do Edit de Grupo de Curso
        /// </summary>
        public static string CourseGroupEditTitle
        {
            get
            {
                return Localize("Edição de Grupo de Curso");
            }
        }

        /// <summary>
        /// Label do botão Create de Grupo de Curso
        /// </summary>
        public static string CourseGroupCreateButton
        {
            get
            {
                return Localize("Novo Grupo de Curso");
            }
        }

        /// <summary>
        /// Label do botão Delete de Grupo de Curso
        /// </summary>
        public static string CourseGroupDeleteButton
        {
            get
            {
                return Localize("Excluir Grupo de Curso");
            }
        }

        /// <summary>
        /// Titulo do index de Versão do Curso
        /// </summary>
        public static string CourseVersionIndexTitle
        {
            get
            {
                return Localize("Versão do Curso");
            }
        }

        /// <summary>
        /// Titulo do Create de Versão do Curso
        /// </summary>
        public static string CourseVersionCreateTitle
        {
            get
            {
                return Localize("Cadastro de Versão do Curso");
            }
        }

        /// <summary>
        /// Titulo do Edit de Versão do Curso
        /// </summary>
        public static string CourseVersionEditTitle
        {
            get
            {
                return Localize("Edição de Versão do Curso");
            }
        }

        /// <summary>
        /// Label do botão Create de Versão do Curso
        /// </summary>
        public static string CourseVersionCreateButton
        {
            get
            {
                return Localize("Novo Versão do Curso");
            }
        }

        /// <summary>
        /// Label do botão Delete de Versão do Curso
        /// </summary>
        public static string CourseVersionDeleteButton
        {
            get
            {
                return Localize("Excluir Versão do Curso");
            }
        }

        /// <summary>
        /// Titulo do index de DaysOfWeek
        /// </summary>
        public static string DaysOfWeekIndexTitle
        {
            get
            {
                return Localize("DaysOfWeek");
            }
        }

        /// <summary>
        /// Titulo do Create de DaysOfWeek
        /// </summary>
        public static string DaysOfWeekCreateTitle
        {
            get
            {
                return Localize("Cadastro de DaysOfWeek");
            }
        }

        /// <summary>
        /// Titulo do Edit de DaysOfWeek
        /// </summary>
        public static string DaysOfWeekEditTitle
        {
            get
            {
                return Localize("Edição de DaysOfWeek");
            }
        }

        /// <summary>
        /// Label do botão Create de DaysOfWeek
        /// </summary>
        public static string DaysOfWeekCreateButton
        {
            get
            {
                return Localize("Novo DaysOfWeek");
            }
        }

        /// <summary>
        /// Label do botão Delete de DaysOfWeek
        /// </summary>
        public static string DaysOfWeekDeleteButton
        {
            get
            {
                return Localize("Excluir DaysOfWeek");
            }
        }

        /// <summary>
        /// Titulo do index de Nível Dificuldade
        /// </summary>
        public static string DifficultyLevelIndexTitle
        {
            get
            {
                return Localize("Nível Dificuldade");
            }
        }

        /// <summary>
        /// Titulo do Create de Nível Dificuldade
        /// </summary>
        public static string DifficultyLevelCreateTitle
        {
            get
            {
                return Localize("Cadastro de Nível Dificuldade");
            }
        }

        /// <summary>
        /// Titulo do Edit de Nível Dificuldade
        /// </summary>
        public static string DifficultyLevelEditTitle
        {
            get
            {
                return Localize("Edição de Nível Dificuldade");
            }
        }

        /// <summary>
        /// Label do botão Create de Nível Dificuldade
        /// </summary>
        public static string DifficultyLevelCreateButton
        {
            get
            {
                return Localize("Novo Nível Dificuldade");
            }
        }

        /// <summary>
        /// Label do botão Delete de Nível Dificuldade
        /// </summary>
        public static string DifficultyLevelDeleteButton
        {
            get
            {
                return Localize("Excluir Nível Dificuldade");
            }
        }

        /// <summary>
        /// Titulo do index de EducationLevel
        /// </summary>
        public static string EducationLevelIndexTitle
        {
            get
            {
                return Localize("EducationLevel");
            }
        }

        /// <summary>
        /// Titulo do Create de EducationLevel
        /// </summary>
        public static string EducationLevelCreateTitle
        {
            get
            {
                return Localize("Cadastro de EducationLevel");
            }
        }

        /// <summary>
        /// Titulo do Edit de EducationLevel
        /// </summary>
        public static string EducationLevelEditTitle
        {
            get
            {
                return Localize("Edição de EducationLevel");
            }
        }

        /// <summary>
        /// Label do botão Create de EducationLevel
        /// </summary>
        public static string EducationLevelCreateButton
        {
            get
            {
                return Localize("Novo EducationLevel");
            }
        }

        /// <summary>
        /// Label do botão Delete de EducationLevel
        /// </summary>
        public static string EducationLevelDeleteButton
        {
            get
            {
                return Localize("Excluir EducationLevel");
            }
        }

        /// <summary>
        /// Titulo do index de EmailQueue
        /// </summary>
        public static string EmailQueueIndexTitle
        {
            get
            {
                return Localize("EmailQueue");
            }
        }

        /// <summary>
        /// Titulo do Create de EmailQueue
        /// </summary>
        public static string EmailQueueCreateTitle
        {
            get
            {
                return Localize("Cadastro de EmailQueue");
            }
        }

        /// <summary>
        /// Titulo do Edit de EmailQueue
        /// </summary>
        public static string EmailQueueEditTitle
        {
            get
            {
                return Localize("Edição de EmailQueue");
            }
        }

        /// <summary>
        /// Label do botão Create de EmailQueue
        /// </summary>
        public static string EmailQueueCreateButton
        {
            get
            {
                return Localize("Novo EmailQueue");
            }
        }

        /// <summary>
        /// Label do botão Delete de EmailQueue
        /// </summary>
        public static string EmailQueueDeleteButton
        {
            get
            {
                return Localize("Excluir EmailQueue");
            }
        }

        /// <summary>
        /// Titulo do index de EmailTemplate
        /// </summary>
        public static string EmailTemplateIndexTitle
        {
            get
            {
                return Localize("EmailTemplate");
            }
        }

        /// <summary>
        /// Titulo do Create de EmailTemplate
        /// </summary>
        public static string EmailTemplateCreateTitle
        {
            get
            {
                return Localize("Cadastro de EmailTemplate");
            }
        }

        /// <summary>
        /// Titulo do Edit de EmailTemplate
        /// </summary>
        public static string EmailTemplateEditTitle
        {
            get
            {
                return Localize("Edição de EmailTemplate");
            }
        }

        /// <summary>
        /// Label do botão Create de EmailTemplate
        /// </summary>
        public static string EmailTemplateCreateButton
        {
            get
            {
                return Localize("Novo EmailTemplate");
            }
        }

        /// <summary>
        /// Label do botão Delete de EmailTemplate
        /// </summary>
        public static string EmailTemplateDeleteButton
        {
            get
            {
                return Localize("Excluir EmailTemplate");
            }
        }

        /// <summary>
        /// Titulo do index de TentativaDiscursiva
        /// </summary>
        public static string EssayAttemptsIndexTitle
        {
            get
            {
                return Localize("TentativaDiscursiva");
            }
        }

        /// <summary>
        /// Titulo do Create de TentativaDiscursiva
        /// </summary>
        public static string EssayAttemptsCreateTitle
        {
            get
            {
                return Localize("Cadastro de TentativaDiscursiva");
            }
        }

        /// <summary>
        /// Titulo do Edit de TentativaDiscursiva
        /// </summary>
        public static string EssayAttemptsEditTitle
        {
            get
            {
                return Localize("Edição de TentativaDiscursiva");
            }
        }

        /// <summary>
        /// Label do botão Create de TentativaDiscursiva
        /// </summary>
        public static string EssayAttemptsCreateButton
        {
            get
            {
                return Localize("Novo TentativaDiscursiva");
            }
        }

        /// <summary>
        /// Label do botão Delete de TentativaDiscursiva
        /// </summary>
        public static string EssayAttemptsDeleteButton
        {
            get
            {
                return Localize("Excluir TentativaDiscursiva");
            }
        }

        /// <summary>
        /// Titulo do index de Discursiva
        /// </summary>
        public static string EssayQuestionIndexTitle
        {
            get
            {
                return Localize("Discursiva");
            }
        }

        /// <summary>
        /// Titulo do Create de Discursiva
        /// </summary>
        public static string EssayQuestionCreateTitle
        {
            get
            {
                return Localize("Cadastro de Discursiva");
            }
        }

        /// <summary>
        /// Titulo do Edit de Discursiva
        /// </summary>
        public static string EssayQuestionEditTitle
        {
            get
            {
                return Localize("Edição de Discursiva");
            }
        }

        /// <summary>
        /// Label do botão Create de Discursiva
        /// </summary>
        public static string EssayQuestionCreateButton
        {
            get
            {
                return Localize("Novo Discursiva");
            }
        }

        /// <summary>
        /// Label do botão Delete de Discursiva
        /// </summary>
        public static string EssayQuestionDeleteButton
        {
            get
            {
                return Localize("Excluir Discursiva");
            }
        }

        /// <summary>
        /// Titulo do index de Expression
        /// </summary>
        public static string ExpressionIndexTitle
        {
            get
            {
                return Localize("Expression");
            }
        }

        /// <summary>
        /// Titulo do Create de Expression
        /// </summary>
        public static string ExpressionCreateTitle
        {
            get
            {
                return Localize("Cadastro de Expression");
            }
        }

        /// <summary>
        /// Titulo do Edit de Expression
        /// </summary>
        public static string ExpressionEditTitle
        {
            get
            {
                return Localize("Edição de Expression");
            }
        }

        /// <summary>
        /// Label do botão Create de Expression
        /// </summary>
        public static string ExpressionCreateButton
        {
            get
            {
                return Localize("Novo Expression");
            }
        }

        /// <summary>
        /// Label do botão Delete de Expression
        /// </summary>
        public static string ExpressionDeleteButton
        {
            get
            {
                return Localize("Excluir Expression");
            }
        }

        /// <summary>
        /// Titulo do index de Feedback
        /// </summary>
        public static string FeedbackIndexTitle
        {
            get
            {
                return Localize("Feedback");
            }
        }

        /// <summary>
        /// Titulo do Create de Feedback
        /// </summary>
        public static string FeedbackCreateTitle
        {
            get
            {
                return Localize("Cadastro de Feedback");
            }
        }

        /// <summary>
        /// Titulo do Edit de Feedback
        /// </summary>
        public static string FeedbackEditTitle
        {
            get
            {
                return Localize("Edição de Feedback");
            }
        }

        /// <summary>
        /// Label do botão Create de Feedback
        /// </summary>
        public static string FeedbackCreateButton
        {
            get
            {
                return Localize("Novo Feedback");
            }
        }

        /// <summary>
        /// Label do botão Delete de Feedback
        /// </summary>
        public static string FeedbackDeleteButton
        {
            get
            {
                return Localize("Excluir Feedback");
            }
        }

        /// <summary>
        /// Titulo do index de Feedback Categoria
        /// </summary>
        public static string FeedbackCategoryIndexTitle
        {
            get
            {
                return Localize("Feedback Categoria");
            }
        }

        /// <summary>
        /// Titulo do Create de Feedback Categoria
        /// </summary>
        public static string FeedbackCategoryCreateTitle
        {
            get
            {
                return Localize("Cadastro de Feedback Categoria");
            }
        }

        /// <summary>
        /// Titulo do Edit de Feedback Categoria
        /// </summary>
        public static string FeedbackCategoryEditTitle
        {
            get
            {
                return Localize("Edição de Feedback Categoria");
            }
        }

        /// <summary>
        /// Label do botão Create de Feedback Categoria
        /// </summary>
        public static string FeedbackCategoryCreateButton
        {
            get
            {
                return Localize("Novo Feedback Categoria");
            }
        }

        /// <summary>
        /// Label do botão Delete de Feedback Categoria
        /// </summary>
        public static string FeedbackCategoryDeleteButton
        {
            get
            {
                return Localize("Excluir Feedback Categoria");
            }
        }

        /// <summary>
        /// Titulo do index de Feedback Alternativa
        /// </summary>
        public static string FeedbackItemIndexTitle
        {
            get
            {
                return Localize("Feedback Alternativa");
            }
        }

        /// <summary>
        /// Titulo do Create de Feedback Alternativa
        /// </summary>
        public static string FeedbackItemCreateTitle
        {
            get
            {
                return Localize("Cadastro de Feedback Alternativa");
            }
        }

        /// <summary>
        /// Titulo do Edit de Feedback Alternativa
        /// </summary>
        public static string FeedbackItemEditTitle
        {
            get
            {
                return Localize("Edição de Feedback Alternativa");
            }
        }

        /// <summary>
        /// Label do botão Create de Feedback Alternativa
        /// </summary>
        public static string FeedbackItemCreateButton
        {
            get
            {
                return Localize("Novo Feedback Alternativa");
            }
        }

        /// <summary>
        /// Label do botão Delete de Feedback Alternativa
        /// </summary>
        public static string FeedbackItemDeleteButton
        {
            get
            {
                return Localize("Excluir Feedback Alternativa");
            }
        }

        /// <summary>
        /// Titulo do index de Feedback Pergunta
        /// </summary>
        public static string FeedbackQuestionIndexTitle
        {
            get
            {
                return Localize("Feedback Pergunta");
            }
        }

        /// <summary>
        /// Titulo do Create de Feedback Pergunta
        /// </summary>
        public static string FeedbackQuestionCreateTitle
        {
            get
            {
                return Localize("Cadastro de Feedback Pergunta");
            }
        }

        /// <summary>
        /// Titulo do Edit de Feedback Pergunta
        /// </summary>
        public static string FeedbackQuestionEditTitle
        {
            get
            {
                return Localize("Edição de Feedback Pergunta");
            }
        }

        /// <summary>
        /// Label do botão Create de Feedback Pergunta
        /// </summary>
        public static string FeedbackQuestionCreateButton
        {
            get
            {
                return Localize("Novo Feedback Pergunta");
            }
        }

        /// <summary>
        /// Label do botão Delete de Feedback Pergunta
        /// </summary>
        public static string FeedbackQuestionDeleteButton
        {
            get
            {
                return Localize("Excluir Feedback Pergunta");
            }
        }

        /// <summary>
        /// Titulo do index de Forum
        /// </summary>
        public static string ForumIndexTitle
        {
            get
            {
                return Localize("Forum");
            }
        }

        /// <summary>
        /// Titulo do Create de Forum
        /// </summary>
        public static string ForumCreateTitle
        {
            get
            {
                return Localize("Cadastro de Forum");
            }
        }

        /// <summary>
        /// Titulo do Edit de Forum
        /// </summary>
        public static string ForumEditTitle
        {
            get
            {
                return Localize("Edição de Forum");
            }
        }

        /// <summary>
        /// Label do botão Create de Forum
        /// </summary>
        public static string ForumCreateButton
        {
            get
            {
                return Localize("Novo Forum");
            }
        }

        /// <summary>
        /// Label do botão Delete de Forum
        /// </summary>
        public static string ForumDeleteButton
        {
            get
            {
                return Localize("Excluir Forum");
            }
        }

        /// <summary>
        /// Titulo do index de ForumClass
        /// </summary>
        public static string ForumClassIndexTitle
        {
            get
            {
                return Localize("ForumClass");
            }
        }

        /// <summary>
        /// Titulo do Create de ForumClass
        /// </summary>
        public static string ForumClassCreateTitle
        {
            get
            {
                return Localize("Cadastro de ForumClass");
            }
        }

        /// <summary>
        /// Titulo do Edit de ForumClass
        /// </summary>
        public static string ForumClassEditTitle
        {
            get
            {
                return Localize("Edição de ForumClass");
            }
        }

        /// <summary>
        /// Label do botão Create de ForumClass
        /// </summary>
        public static string ForumClassCreateButton
        {
            get
            {
                return Localize("Novo ForumClass");
            }
        }

        /// <summary>
        /// Label do botão Delete de ForumClass
        /// </summary>
        public static string ForumClassDeleteButton
        {
            get
            {
                return Localize("Excluir ForumClass");
            }
        }

        /// <summary>
        /// Titulo do index de ForumCommunity
        /// </summary>
        public static string ForumCommunityIndexTitle
        {
            get
            {
                return Localize("ForumCommunity");
            }
        }

        /// <summary>
        /// Titulo do Create de ForumCommunity
        /// </summary>
        public static string ForumCommunityCreateTitle
        {
            get
            {
                return Localize("Cadastro de ForumCommunity");
            }
        }

        /// <summary>
        /// Titulo do Edit de ForumCommunity
        /// </summary>
        public static string ForumCommunityEditTitle
        {
            get
            {
                return Localize("Edição de ForumCommunity");
            }
        }

        /// <summary>
        /// Label do botão Create de ForumCommunity
        /// </summary>
        public static string ForumCommunityCreateButton
        {
            get
            {
                return Localize("Novo ForumCommunity");
            }
        }

        /// <summary>
        /// Label do botão Delete de ForumCommunity
        /// </summary>
        public static string ForumCommunityDeleteButton
        {
            get
            {
                return Localize("Excluir ForumCommunity");
            }
        }

        /// <summary>
        /// Titulo do index de ForumCourse
        /// </summary>
        public static string ForumCourseIndexTitle
        {
            get
            {
                return Localize("ForumCourse");
            }
        }

        /// <summary>
        /// Titulo do Create de ForumCourse
        /// </summary>
        public static string ForumCourseCreateTitle
        {
            get
            {
                return Localize("Cadastro de ForumCourse");
            }
        }

        /// <summary>
        /// Titulo do Edit de ForumCourse
        /// </summary>
        public static string ForumCourseEditTitle
        {
            get
            {
                return Localize("Edição de ForumCourse");
            }
        }

        /// <summary>
        /// Label do botão Create de ForumCourse
        /// </summary>
        public static string ForumCourseCreateButton
        {
            get
            {
                return Localize("Novo ForumCourse");
            }
        }

        /// <summary>
        /// Label do botão Delete de ForumCourse
        /// </summary>
        public static string ForumCourseDeleteButton
        {
            get
            {
                return Localize("Excluir ForumCourse");
            }
        }

        /// <summary>
        /// Titulo do index de ForumPost
        /// </summary>
        public static string ForumPostIndexTitle
        {
            get
            {
                return Localize("ForumPost");
            }
        }

        /// <summary>
        /// Titulo do Create de ForumPost
        /// </summary>
        public static string ForumPostCreateTitle
        {
            get
            {
                return Localize("Cadastro de ForumPost");
            }
        }

        /// <summary>
        /// Titulo do Edit de ForumPost
        /// </summary>
        public static string ForumPostEditTitle
        {
            get
            {
                return Localize("Edição de ForumPost");
            }
        }

        /// <summary>
        /// Label do botão Create de ForumPost
        /// </summary>
        public static string ForumPostCreateButton
        {
            get
            {
                return Localize("Novo ForumPost");
            }
        }

        /// <summary>
        /// Label do botão Delete de ForumPost
        /// </summary>
        public static string ForumPostDeleteButton
        {
            get
            {
                return Localize("Excluir ForumPost");
            }
        }

        /// <summary>
        /// Titulo do index de ForumTopic
        /// </summary>
        public static string ForumTopicIndexTitle
        {
            get
            {
                return Localize("ForumTopic");
            }
        }

        /// <summary>
        /// Titulo do Create de ForumTopic
        /// </summary>
        public static string ForumTopicCreateTitle
        {
            get
            {
                return Localize("Cadastro de ForumTopic");
            }
        }

        /// <summary>
        /// Titulo do Edit de ForumTopic
        /// </summary>
        public static string ForumTopicEditTitle
        {
            get
            {
                return Localize("Edição de ForumTopic");
            }
        }

        /// <summary>
        /// Label do botão Create de ForumTopic
        /// </summary>
        public static string ForumTopicCreateButton
        {
            get
            {
                return Localize("Novo ForumTopic");
            }
        }

        /// <summary>
        /// Label do botão Delete de ForumTopic
        /// </summary>
        public static string ForumTopicDeleteButton
        {
            get
            {
                return Localize("Excluir ForumTopic");
            }
        }

        /// <summary>
        /// Titulo do index de Glossário
        /// </summary>
        public static string GlossaryIndexTitle
        {
            get
            {
                return Localize("Glossário");
            }
        }

        /// <summary>
        /// Titulo do Create de Glossário
        /// </summary>
        public static string GlossaryCreateTitle
        {
            get
            {
                return Localize("Cadastro de Glossário");
            }
        }

        /// <summary>
        /// Titulo do Edit de Glossário
        /// </summary>
        public static string GlossaryEditTitle
        {
            get
            {
                return Localize("Edição de Glossário");
            }
        }

        /// <summary>
        /// Label do botão Create de Glossário
        /// </summary>
        public static string GlossaryCreateButton
        {
            get
            {
                return Localize("Novo Glossário");
            }
        }

        /// <summary>
        /// Label do botão Delete de Glossário
        /// </summary>
        public static string GlossaryDeleteButton
        {
            get
            {
                return Localize("Excluir Glossário");
            }
        }

        /// <summary>
        /// Titulo do index de Objeto de Aprendizagem Instanciados
        /// </summary>
        public static string InstantiatedLearningObjectsIndexTitle
        {
            get
            {
                return Localize("Objeto de Aprendizagem Instanciados");
            }
        }

        /// <summary>
        /// Titulo do Create de Objeto de Aprendizagem Instanciados
        /// </summary>
        public static string InstantiatedLearningObjectsCreateTitle
        {
            get
            {
                return Localize("Cadastro de Objeto de Aprendizagem Instanciados");
            }
        }

        /// <summary>
        /// Titulo do Edit de Objeto de Aprendizagem Instanciados
        /// </summary>
        public static string InstantiatedLearningObjectsEditTitle
        {
            get
            {
                return Localize("Edição de Objeto de Aprendizagem Instanciados");
            }
        }

        /// <summary>
        /// Label do botão Create de Objeto de Aprendizagem Instanciados
        /// </summary>
        public static string InstantiatedLearningObjectsCreateButton
        {
            get
            {
                return Localize("Novo Objeto de Aprendizagem Instanciados");
            }
        }

        /// <summary>
        /// Label do botão Delete de Objeto de Aprendizagem Instanciados
        /// </summary>
        public static string InstantiatedLearningObjectsDeleteButton
        {
            get
            {
                return Localize("Excluir Objeto de Aprendizagem Instanciados");
            }
        }

        /// <summary>
        /// Titulo do index de Faixa de IP
        /// </summary>
        public static string IPRangeIndexTitle
        {
            get
            {
                return Localize("Faixa de IP");
            }
        }

        /// <summary>
        /// Titulo do Create de Faixa de IP
        /// </summary>
        public static string IPRangeCreateTitle
        {
            get
            {
                return Localize("Cadastro de Faixa de IP");
            }
        }

        /// <summary>
        /// Titulo do Edit de Faixa de IP
        /// </summary>
        public static string IPRangeEditTitle
        {
            get
            {
                return Localize("Edição de Faixa de IP");
            }
        }

        /// <summary>
        /// Label do botão Create de Faixa de IP
        /// </summary>
        public static string IPRangeCreateButton
        {
            get
            {
                return Localize("Novo Faixa de IP");
            }
        }

        /// <summary>
        /// Label do botão Delete de Faixa de IP
        /// </summary>
        public static string IPRangeDeleteButton
        {
            get
            {
                return Localize("Excluir Faixa de IP");
            }
        }

        /// <summary>
        /// Titulo do index de JobTitle
        /// </summary>
        public static string JobTitleIndexTitle
        {
            get
            {
                return Localize("JobTitle");
            }
        }

        /// <summary>
        /// Titulo do Create de JobTitle
        /// </summary>
        public static string JobTitleCreateTitle
        {
            get
            {
                return Localize("Cadastro de JobTitle");
            }
        }

        /// <summary>
        /// Titulo do Edit de JobTitle
        /// </summary>
        public static string JobTitleEditTitle
        {
            get
            {
                return Localize("Edição de JobTitle");
            }
        }

        /// <summary>
        /// Label do botão Create de JobTitle
        /// </summary>
        public static string JobTitleCreateButton
        {
            get
            {
                return Localize("Novo JobTitle");
            }
        }

        /// <summary>
        /// Label do botão Delete de JobTitle
        /// </summary>
        public static string JobTitleDeleteButton
        {
            get
            {
                return Localize("Excluir JobTitle");
            }
        }

        /// <summary>
        /// Titulo do index de Objeto de Aprendizagem
        /// </summary>
        public static string LearningObjectIndexTitle
        {
            get
            {
                return Localize("Objeto de Aprendizagem");
            }
        }

        /// <summary>
        /// Titulo do Create de Objeto de Aprendizagem
        /// </summary>
        public static string LearningObjectCreateTitle
        {
            get
            {
                return Localize("Cadastro de Objeto de Aprendizagem");
            }
        }

        /// <summary>
        /// Titulo do Edit de Objeto de Aprendizagem
        /// </summary>
        public static string LearningObjectEditTitle
        {
            get
            {
                return Localize("Edição de Objeto de Aprendizagem");
            }
        }

        /// <summary>
        /// Label do botão Create de Objeto de Aprendizagem
        /// </summary>
        public static string LearningObjectCreateButton
        {
            get
            {
                return Localize("Novo Objeto de Aprendizagem");
            }
        }

        /// <summary>
        /// Label do botão Delete de Objeto de Aprendizagem
        /// </summary>
        public static string LearningObjectDeleteButton
        {
            get
            {
                return Localize("Excluir Objeto de Aprendizagem");
            }
        }

        /// <summary>
        /// Titulo do index de Avaliação Presencial
        /// </summary>
        public static string LocalAssessmentIndexTitle
        {
            get
            {
                return Localize("Avaliação Presencial");
            }
        }

        /// <summary>
        /// Titulo do Create de Avaliação Presencial
        /// </summary>
        public static string LocalAssessmentCreateTitle
        {
            get
            {
                return Localize("Cadastro de Avaliação Presencial");
            }
        }

        /// <summary>
        /// Titulo do Edit de Avaliação Presencial
        /// </summary>
        public static string LocalAssessmentEditTitle
        {
            get
            {
                return Localize("Edição de Avaliação Presencial");
            }
        }

        /// <summary>
        /// Label do botão Create de Avaliação Presencial
        /// </summary>
        public static string LocalAssessmentCreateButton
        {
            get
            {
                return Localize("Novo Avaliação Presencial");
            }
        }

        /// <summary>
        /// Label do botão Delete de Avaliação Presencial
        /// </summary>
        public static string LocalAssessmentDeleteButton
        {
            get
            {
                return Localize("Excluir Avaliação Presencial");
            }
        }

        /// <summary>
        /// Titulo do index de Turma Presencial
        /// </summary>
        public static string LocalClassroomIndexTitle
        {
            get
            {
                return Localize("Turma Presencial");
            }
        }

        /// <summary>
        /// Titulo do Create de Turma Presencial
        /// </summary>
        public static string LocalClassroomCreateTitle
        {
            get
            {
                return Localize("Cadastro de Turma Presencial");
            }
        }

        /// <summary>
        /// Titulo do Edit de Turma Presencial
        /// </summary>
        public static string LocalClassroomEditTitle
        {
            get
            {
                return Localize("Edição de Turma Presencial");
            }
        }

        /// <summary>
        /// Label do botão Create de Turma Presencial
        /// </summary>
        public static string LocalClassroomCreateButton
        {
            get
            {
                return Localize("Novo Turma Presencial");
            }
        }

        /// <summary>
        /// Label do botão Delete de Turma Presencial
        /// </summary>
        public static string LocalClassroomDeleteButton
        {
            get
            {
                return Localize("Excluir Turma Presencial");
            }
        }

        /// <summary>
        /// Titulo do index de Aula Presencial
        /// </summary>
        public static string LocalLessonIndexTitle
        {
            get
            {
                return Localize("Aula Presencial");
            }
        }

        /// <summary>
        /// Titulo do Create de Aula Presencial
        /// </summary>
        public static string LocalLessonCreateTitle
        {
            get
            {
                return Localize("Cadastro de Aula Presencial");
            }
        }

        /// <summary>
        /// Titulo do Edit de Aula Presencial
        /// </summary>
        public static string LocalLessonEditTitle
        {
            get
            {
                return Localize("Edição de Aula Presencial");
            }
        }

        /// <summary>
        /// Label do botão Create de Aula Presencial
        /// </summary>
        public static string LocalLessonCreateButton
        {
            get
            {
                return Localize("Novo Aula Presencial");
            }
        }

        /// <summary>
        /// Label do botão Delete de Aula Presencial
        /// </summary>
        public static string LocalLessonDeleteButton
        {
            get
            {
                return Localize("Excluir Aula Presencial");
            }
        }

        /// <summary>
        /// Titulo do index de MaritalStatus
        /// </summary>
        public static string MaritalStatusIndexTitle
        {
            get
            {
                return Localize("MaritalStatus");
            }
        }

        /// <summary>
        /// Titulo do Create de MaritalStatus
        /// </summary>
        public static string MaritalStatusCreateTitle
        {
            get
            {
                return Localize("Cadastro de MaritalStatus");
            }
        }

        /// <summary>
        /// Titulo do Edit de MaritalStatus
        /// </summary>
        public static string MaritalStatusEditTitle
        {
            get
            {
                return Localize("Edição de MaritalStatus");
            }
        }

        /// <summary>
        /// Label do botão Create de MaritalStatus
        /// </summary>
        public static string MaritalStatusCreateButton
        {
            get
            {
                return Localize("Novo MaritalStatus");
            }
        }

        /// <summary>
        /// Label do botão Delete de MaritalStatus
        /// </summary>
        public static string MaritalStatusDeleteButton
        {
            get
            {
                return Localize("Excluir MaritalStatus");
            }
        }

        /// <summary>
        /// Titulo do index de Correspondente
        /// </summary>
        public static string MatchingItemIndexTitle
        {
            get
            {
                return Localize("Correspondente");
            }
        }

        /// <summary>
        /// Titulo do Create de Correspondente
        /// </summary>
        public static string MatchingItemCreateTitle
        {
            get
            {
                return Localize("Cadastro de Correspondente");
            }
        }

        /// <summary>
        /// Titulo do Edit de Correspondente
        /// </summary>
        public static string MatchingItemEditTitle
        {
            get
            {
                return Localize("Edição de Correspondente");
            }
        }

        /// <summary>
        /// Label do botão Create de Correspondente
        /// </summary>
        public static string MatchingItemCreateButton
        {
            get
            {
                return Localize("Novo Correspondente");
            }
        }

        /// <summary>
        /// Label do botão Delete de Correspondente
        /// </summary>
        public static string MatchingItemDeleteButton
        {
            get
            {
                return Localize("Excluir Correspondente");
            }
        }

        /// <summary>
        /// Titulo do index de Associar Colunas
        /// </summary>
        public static string MatchingQuestionIndexTitle
        {
            get
            {
                return Localize("Associar Colunas");
            }
        }

        /// <summary>
        /// Titulo do Create de Associar Colunas
        /// </summary>
        public static string MatchingQuestionCreateTitle
        {
            get
            {
                return Localize("Cadastro de Associar Colunas");
            }
        }

        /// <summary>
        /// Titulo do Edit de Associar Colunas
        /// </summary>
        public static string MatchingQuestionEditTitle
        {
            get
            {
                return Localize("Edição de Associar Colunas");
            }
        }

        /// <summary>
        /// Label do botão Create de Associar Colunas
        /// </summary>
        public static string MatchingQuestionCreateButton
        {
            get
            {
                return Localize("Novo Associar Colunas");
            }
        }

        /// <summary>
        /// Label do botão Delete de Associar Colunas
        /// </summary>
        public static string MatchingQuestionDeleteButton
        {
            get
            {
                return Localize("Excluir Associar Colunas");
            }
        }

        /// <summary>
        /// Titulo do index de TentativaAssociarColunas
        /// </summary>
        public static string MatchingQuestionAttemptsIndexTitle
        {
            get
            {
                return Localize("TentativaAssociarColunas");
            }
        }

        /// <summary>
        /// Titulo do Create de TentativaAssociarColunas
        /// </summary>
        public static string MatchingQuestionAttemptsCreateTitle
        {
            get
            {
                return Localize("Cadastro de TentativaAssociarColunas");
            }
        }

        /// <summary>
        /// Titulo do Edit de TentativaAssociarColunas
        /// </summary>
        public static string MatchingQuestionAttemptsEditTitle
        {
            get
            {
                return Localize("Edição de TentativaAssociarColunas");
            }
        }

        /// <summary>
        /// Label do botão Create de TentativaAssociarColunas
        /// </summary>
        public static string MatchingQuestionAttemptsCreateButton
        {
            get
            {
                return Localize("Novo TentativaAssociarColunas");
            }
        }

        /// <summary>
        /// Label do botão Delete de TentativaAssociarColunas
        /// </summary>
        public static string MatchingQuestionAttemptsDeleteButton
        {
            get
            {
                return Localize("Excluir TentativaAssociarColunas");
            }
        }

        /// <summary>
        /// Titulo do index de Colunas Questão
        /// </summary>
        public static string MatchingQuestionItemIndexTitle
        {
            get
            {
                return Localize("Colunas Questão");
            }
        }

        /// <summary>
        /// Titulo do Create de Colunas Questão
        /// </summary>
        public static string MatchingQuestionItemCreateTitle
        {
            get
            {
                return Localize("Cadastro de Colunas Questão");
            }
        }

        /// <summary>
        /// Titulo do Edit de Colunas Questão
        /// </summary>
        public static string MatchingQuestionItemEditTitle
        {
            get
            {
                return Localize("Edição de Colunas Questão");
            }
        }

        /// <summary>
        /// Label do botão Create de Colunas Questão
        /// </summary>
        public static string MatchingQuestionItemCreateButton
        {
            get
            {
                return Localize("Novo Colunas Questão");
            }
        }

        /// <summary>
        /// Label do botão Delete de Colunas Questão
        /// </summary>
        public static string MatchingQuestionItemDeleteButton
        {
            get
            {
                return Localize("Excluir Colunas Questão");
            }
        }

        /// <summary>
        /// Titulo do index de Media
        /// </summary>
        public static string MediaIndexTitle
        {
            get
            {
                return Localize("Media");
            }
        }

        /// <summary>
        /// Titulo do Create de Media
        /// </summary>
        public static string MediaCreateTitle
        {
            get
            {
                return Localize("Cadastro de Media");
            }
        }

        /// <summary>
        /// Titulo do Edit de Media
        /// </summary>
        public static string MediaEditTitle
        {
            get
            {
                return Localize("Edição de Media");
            }
        }

        /// <summary>
        /// Label do botão Create de Media
        /// </summary>
        public static string MediaCreateButton
        {
            get
            {
                return Localize("Novo Media");
            }
        }

        /// <summary>
        /// Label do botão Delete de Media
        /// </summary>
        public static string MediaDeleteButton
        {
            get
            {
                return Localize("Excluir Media");
            }
        }

        /// <summary>
        /// Titulo do index de MediaArea
        /// </summary>
        public static string MediaAreaIndexTitle
        {
            get
            {
                return Localize("MediaArea");
            }
        }

        /// <summary>
        /// Titulo do Create de MediaArea
        /// </summary>
        public static string MediaAreaCreateTitle
        {
            get
            {
                return Localize("Cadastro de MediaArea");
            }
        }

        /// <summary>
        /// Titulo do Edit de MediaArea
        /// </summary>
        public static string MediaAreaEditTitle
        {
            get
            {
                return Localize("Edição de MediaArea");
            }
        }

        /// <summary>
        /// Label do botão Create de MediaArea
        /// </summary>
        public static string MediaAreaCreateButton
        {
            get
            {
                return Localize("Novo MediaArea");
            }
        }

        /// <summary>
        /// Label do botão Delete de MediaArea
        /// </summary>
        public static string MediaAreaDeleteButton
        {
            get
            {
                return Localize("Excluir MediaArea");
            }
        }

        /// <summary>
        /// Titulo do index de MediaClass
        /// </summary>
        public static string MediaClassIndexTitle
        {
            get
            {
                return Localize("MediaClass");
            }
        }

        /// <summary>
        /// Titulo do Create de MediaClass
        /// </summary>
        public static string MediaClassCreateTitle
        {
            get
            {
                return Localize("Cadastro de MediaClass");
            }
        }

        /// <summary>
        /// Titulo do Edit de MediaClass
        /// </summary>
        public static string MediaClassEditTitle
        {
            get
            {
                return Localize("Edição de MediaClass");
            }
        }

        /// <summary>
        /// Label do botão Create de MediaClass
        /// </summary>
        public static string MediaClassCreateButton
        {
            get
            {
                return Localize("Novo MediaClass");
            }
        }

        /// <summary>
        /// Label do botão Delete de MediaClass
        /// </summary>
        public static string MediaClassDeleteButton
        {
            get
            {
                return Localize("Excluir MediaClass");
            }
        }

        /// <summary>
        /// Titulo do index de MediaCommunity
        /// </summary>
        public static string MediaCommunityIndexTitle
        {
            get
            {
                return Localize("MediaCommunity");
            }
        }

        /// <summary>
        /// Titulo do Create de MediaCommunity
        /// </summary>
        public static string MediaCommunityCreateTitle
        {
            get
            {
                return Localize("Cadastro de MediaCommunity");
            }
        }

        /// <summary>
        /// Titulo do Edit de MediaCommunity
        /// </summary>
        public static string MediaCommunityEditTitle
        {
            get
            {
                return Localize("Edição de MediaCommunity");
            }
        }

        /// <summary>
        /// Label do botão Create de MediaCommunity
        /// </summary>
        public static string MediaCommunityCreateButton
        {
            get
            {
                return Localize("Novo MediaCommunity");
            }
        }

        /// <summary>
        /// Label do botão Delete de MediaCommunity
        /// </summary>
        public static string MediaCommunityDeleteButton
        {
            get
            {
                return Localize("Excluir MediaCommunity");
            }
        }

        /// <summary>
        /// Titulo do index de MediaCourse
        /// </summary>
        public static string MediaCourseIndexTitle
        {
            get
            {
                return Localize("MediaCourse");
            }
        }

        /// <summary>
        /// Titulo do Create de MediaCourse
        /// </summary>
        public static string MediaCourseCreateTitle
        {
            get
            {
                return Localize("Cadastro de MediaCourse");
            }
        }

        /// <summary>
        /// Titulo do Edit de MediaCourse
        /// </summary>
        public static string MediaCourseEditTitle
        {
            get
            {
                return Localize("Edição de MediaCourse");
            }
        }

        /// <summary>
        /// Label do botão Create de MediaCourse
        /// </summary>
        public static string MediaCourseCreateButton
        {
            get
            {
                return Localize("Novo MediaCourse");
            }
        }

        /// <summary>
        /// Label do botão Delete de MediaCourse
        /// </summary>
        public static string MediaCourseDeleteButton
        {
            get
            {
                return Localize("Excluir MediaCourse");
            }
        }

        /// <summary>
        /// Titulo do index de MediaProfile
        /// </summary>
        public static string MediaProfileIndexTitle
        {
            get
            {
                return Localize("MediaProfile");
            }
        }

        /// <summary>
        /// Titulo do Create de MediaProfile
        /// </summary>
        public static string MediaProfileCreateTitle
        {
            get
            {
                return Localize("Cadastro de MediaProfile");
            }
        }

        /// <summary>
        /// Titulo do Edit de MediaProfile
        /// </summary>
        public static string MediaProfileEditTitle
        {
            get
            {
                return Localize("Edição de MediaProfile");
            }
        }

        /// <summary>
        /// Label do botão Create de MediaProfile
        /// </summary>
        public static string MediaProfileCreateButton
        {
            get
            {
                return Localize("Novo MediaProfile");
            }
        }

        /// <summary>
        /// Label do botão Delete de MediaProfile
        /// </summary>
        public static string MediaProfileDeleteButton
        {
            get
            {
                return Localize("Excluir MediaProfile");
            }
        }

        /// <summary>
        /// Titulo do index de MediaProgram
        /// </summary>
        public static string MediaProgramIndexTitle
        {
            get
            {
                return Localize("MediaProgram");
            }
        }

        /// <summary>
        /// Titulo do Create de MediaProgram
        /// </summary>
        public static string MediaProgramCreateTitle
        {
            get
            {
                return Localize("Cadastro de MediaProgram");
            }
        }

        /// <summary>
        /// Titulo do Edit de MediaProgram
        /// </summary>
        public static string MediaProgramEditTitle
        {
            get
            {
                return Localize("Edição de MediaProgram");
            }
        }

        /// <summary>
        /// Label do botão Create de MediaProgram
        /// </summary>
        public static string MediaProgramCreateButton
        {
            get
            {
                return Localize("Novo MediaProgram");
            }
        }

        /// <summary>
        /// Label do botão Delete de MediaProgram
        /// </summary>
        public static string MediaProgramDeleteButton
        {
            get
            {
                return Localize("Excluir MediaProgram");
            }
        }

        /// <summary>
        /// Titulo do index de MediaTag
        /// </summary>
        public static string MediaTagIndexTitle
        {
            get
            {
                return Localize("MediaTag");
            }
        }

        /// <summary>
        /// Titulo do Create de MediaTag
        /// </summary>
        public static string MediaTagCreateTitle
        {
            get
            {
                return Localize("Cadastro de MediaTag");
            }
        }

        /// <summary>
        /// Titulo do Edit de MediaTag
        /// </summary>
        public static string MediaTagEditTitle
        {
            get
            {
                return Localize("Edição de MediaTag");
            }
        }

        /// <summary>
        /// Label do botão Create de MediaTag
        /// </summary>
        public static string MediaTagCreateButton
        {
            get
            {
                return Localize("Novo MediaTag");
            }
        }

        /// <summary>
        /// Label do botão Delete de MediaTag
        /// </summary>
        public static string MediaTagDeleteButton
        {
            get
            {
                return Localize("Excluir MediaTag");
            }
        }

        /// <summary>
        /// Titulo do index de MediaUnit
        /// </summary>
        public static string MediaUnitIndexTitle
        {
            get
            {
                return Localize("MediaUnit");
            }
        }

        /// <summary>
        /// Titulo do Create de MediaUnit
        /// </summary>
        public static string MediaUnitCreateTitle
        {
            get
            {
                return Localize("Cadastro de MediaUnit");
            }
        }

        /// <summary>
        /// Titulo do Edit de MediaUnit
        /// </summary>
        public static string MediaUnitEditTitle
        {
            get
            {
                return Localize("Edição de MediaUnit");
            }
        }

        /// <summary>
        /// Label do botão Create de MediaUnit
        /// </summary>
        public static string MediaUnitCreateButton
        {
            get
            {
                return Localize("Novo MediaUnit");
            }
        }

        /// <summary>
        /// Label do botão Delete de MediaUnit
        /// </summary>
        public static string MediaUnitDeleteButton
        {
            get
            {
                return Localize("Excluir MediaUnit");
            }
        }

        /// <summary>
        /// Titulo do index de MediaAccess
        /// </summary>
        public static string MediaAccessIndexTitle
        {
            get
            {
                return Localize("MediaAccess");
            }
        }

        /// <summary>
        /// Titulo do Create de MediaAccess
        /// </summary>
        public static string MediaAccessCreateTitle
        {
            get
            {
                return Localize("Cadastro de MediaAccess");
            }
        }

        /// <summary>
        /// Titulo do Edit de MediaAccess
        /// </summary>
        public static string MediaAccessEditTitle
        {
            get
            {
                return Localize("Edição de MediaAccess");
            }
        }

        /// <summary>
        /// Label do botão Create de MediaAccess
        /// </summary>
        public static string MediaAccessCreateButton
        {
            get
            {
                return Localize("Novo MediaAccess");
            }
        }

        /// <summary>
        /// Label do botão Delete de MediaAccess
        /// </summary>
        public static string MediaAccessDeleteButton
        {
            get
            {
                return Localize("Excluir MediaAccess");
            }
        }

        /// <summary>
        /// Titulo do index de MediaCategory
        /// </summary>
        public static string MediaCategoryIndexTitle
        {
            get
            {
                return Localize("MediaCategory");
            }
        }

        /// <summary>
        /// Titulo do Create de MediaCategory
        /// </summary>
        public static string MediaCategoryCreateTitle
        {
            get
            {
                return Localize("Cadastro de MediaCategory");
            }
        }

        /// <summary>
        /// Titulo do Edit de MediaCategory
        /// </summary>
        public static string MediaCategoryEditTitle
        {
            get
            {
                return Localize("Edição de MediaCategory");
            }
        }

        /// <summary>
        /// Label do botão Create de MediaCategory
        /// </summary>
        public static string MediaCategoryCreateButton
        {
            get
            {
                return Localize("Novo MediaCategory");
            }
        }

        /// <summary>
        /// Label do botão Delete de MediaCategory
        /// </summary>
        public static string MediaCategoryDeleteButton
        {
            get
            {
                return Localize("Excluir MediaCategory");
            }
        }

        /// <summary>
        /// Titulo do index de MediaDocument
        /// </summary>
        public static string MediaDocumentIndexTitle
        {
            get
            {
                return Localize("MediaDocument");
            }
        }

        /// <summary>
        /// Titulo do Create de MediaDocument
        /// </summary>
        public static string MediaDocumentCreateTitle
        {
            get
            {
                return Localize("Cadastro de MediaDocument");
            }
        }

        /// <summary>
        /// Titulo do Edit de MediaDocument
        /// </summary>
        public static string MediaDocumentEditTitle
        {
            get
            {
                return Localize("Edição de MediaDocument");
            }
        }

        /// <summary>
        /// Label do botão Create de MediaDocument
        /// </summary>
        public static string MediaDocumentCreateButton
        {
            get
            {
                return Localize("Novo MediaDocument");
            }
        }

        /// <summary>
        /// Label do botão Delete de MediaDocument
        /// </summary>
        public static string MediaDocumentDeleteButton
        {
            get
            {
                return Localize("Excluir MediaDocument");
            }
        }

        /// <summary>
        /// Titulo do index de MembershipUser
        /// </summary>
        public static string MembershipUserIndexTitle
        {
            get
            {
                return Localize("MembershipUser");
            }
        }

        /// <summary>
        /// Titulo do Create de MembershipUser
        /// </summary>
        public static string MembershipUserCreateTitle
        {
            get
            {
                return Localize("Cadastro de MembershipUser");
            }
        }

        /// <summary>
        /// Titulo do Edit de MembershipUser
        /// </summary>
        public static string MembershipUserEditTitle
        {
            get
            {
                return Localize("Edição de MembershipUser");
            }
        }

        /// <summary>
        /// Label do botão Create de MembershipUser
        /// </summary>
        public static string MembershipUserCreateButton
        {
            get
            {
                return Localize("Novo MembershipUser");
            }
        }

        /// <summary>
        /// Label do botão Delete de MembershipUser
        /// </summary>
        public static string MembershipUserDeleteButton
        {
            get
            {
                return Localize("Excluir MembershipUser");
            }
        }

        /// <summary>
        /// Titulo do index de Plano de Tutoria
        /// </summary>
        public static string MentoringPlanIndexTitle
        {
            get
            {
                return Localize("Plano de Tutoria");
            }
        }

        /// <summary>
        /// Titulo do Create de Plano de Tutoria
        /// </summary>
        public static string MentoringPlanCreateTitle
        {
            get
            {
                return Localize("Cadastro de Plano de Tutoria");
            }
        }

        /// <summary>
        /// Titulo do Edit de Plano de Tutoria
        /// </summary>
        public static string MentoringPlanEditTitle
        {
            get
            {
                return Localize("Edição de Plano de Tutoria");
            }
        }

        /// <summary>
        /// Label do botão Create de Plano de Tutoria
        /// </summary>
        public static string MentoringPlanCreateButton
        {
            get
            {
                return Localize("Novo Plano de Tutoria");
            }
        }

        /// <summary>
        /// Label do botão Delete de Plano de Tutoria
        /// </summary>
        public static string MentoringPlanDeleteButton
        {
            get
            {
                return Localize("Excluir Plano de Tutoria");
            }
        }

        /// <summary>
        /// Titulo do index de Atividade Plano de Tutoria
        /// </summary>
        public static string MentoringPlanActivityIndexTitle
        {
            get
            {
                return Localize("Atividade Plano de Tutoria");
            }
        }

        /// <summary>
        /// Titulo do Create de Atividade Plano de Tutoria
        /// </summary>
        public static string MentoringPlanActivityCreateTitle
        {
            get
            {
                return Localize("Cadastro de Atividade Plano de Tutoria");
            }
        }

        /// <summary>
        /// Titulo do Edit de Atividade Plano de Tutoria
        /// </summary>
        public static string MentoringPlanActivityEditTitle
        {
            get
            {
                return Localize("Edição de Atividade Plano de Tutoria");
            }
        }

        /// <summary>
        /// Label do botão Create de Atividade Plano de Tutoria
        /// </summary>
        public static string MentoringPlanActivityCreateButton
        {
            get
            {
                return Localize("Novo Atividade Plano de Tutoria");
            }
        }

        /// <summary>
        /// Label do botão Delete de Atividade Plano de Tutoria
        /// </summary>
        public static string MentoringPlanActivityDeleteButton
        {
            get
            {
                return Localize("Excluir Atividade Plano de Tutoria");
            }
        }

        /// <summary>
        /// Titulo do index de Menu
        /// </summary>
        public static string MenuIndexTitle
        {
            get
            {
                return Localize("Menu");
            }
        }

        /// <summary>
        /// Titulo do Create de Menu
        /// </summary>
        public static string MenuCreateTitle
        {
            get
            {
                return Localize("Cadastro de Menu");
            }
        }

        /// <summary>
        /// Titulo do Edit de Menu
        /// </summary>
        public static string MenuEditTitle
        {
            get
            {
                return Localize("Edição de Menu");
            }
        }

        /// <summary>
        /// Label do botão Create de Menu
        /// </summary>
        public static string MenuCreateButton
        {
            get
            {
                return Localize("Novo Menu");
            }
        }

        /// <summary>
        /// Label do botão Delete de Menu
        /// </summary>
        public static string MenuDeleteButton
        {
            get
            {
                return Localize("Excluir Menu");
            }
        }

        /// <summary>
        /// Titulo do index de Message
        /// </summary>
        public static string MessageIndexTitle
        {
            get
            {
                return Localize("Message");
            }
        }

        /// <summary>
        /// Titulo do Create de Message
        /// </summary>
        public static string MessageCreateTitle
        {
            get
            {
                return Localize("Cadastro de Message");
            }
        }

        /// <summary>
        /// Titulo do Edit de Message
        /// </summary>
        public static string MessageEditTitle
        {
            get
            {
                return Localize("Edição de Message");
            }
        }

        /// <summary>
        /// Label do botão Create de Message
        /// </summary>
        public static string MessageCreateButton
        {
            get
            {
                return Localize("Novo Message");
            }
        }

        /// <summary>
        /// Label do botão Delete de Message
        /// </summary>
        public static string MessageDeleteButton
        {
            get
            {
                return Localize("Excluir Message");
            }
        }

        /// <summary>
        /// Titulo do index de MessageFolder
        /// </summary>
        public static string MessageFolderIndexTitle
        {
            get
            {
                return Localize("MessageFolder");
            }
        }

        /// <summary>
        /// Titulo do Create de MessageFolder
        /// </summary>
        public static string MessageFolderCreateTitle
        {
            get
            {
                return Localize("Cadastro de MessageFolder");
            }
        }

        /// <summary>
        /// Titulo do Edit de MessageFolder
        /// </summary>
        public static string MessageFolderEditTitle
        {
            get
            {
                return Localize("Edição de MessageFolder");
            }
        }

        /// <summary>
        /// Label do botão Create de MessageFolder
        /// </summary>
        public static string MessageFolderCreateButton
        {
            get
            {
                return Localize("Novo MessageFolder");
            }
        }

        /// <summary>
        /// Label do botão Delete de MessageFolder
        /// </summary>
        public static string MessageFolderDeleteButton
        {
            get
            {
                return Localize("Excluir MessageFolder");
            }
        }

        /// <summary>
        /// Titulo do index de Module
        /// </summary>
        public static string ModuleIndexTitle
        {
            get
            {
                return Localize("Module");
            }
        }

        /// <summary>
        /// Titulo do Create de Module
        /// </summary>
        public static string ModuleCreateTitle
        {
            get
            {
                return Localize("Cadastro de Module");
            }
        }

        /// <summary>
        /// Titulo do Edit de Module
        /// </summary>
        public static string ModuleEditTitle
        {
            get
            {
                return Localize("Edição de Module");
            }
        }

        /// <summary>
        /// Label do botão Create de Module
        /// </summary>
        public static string ModuleCreateButton
        {
            get
            {
                return Localize("Novo Module");
            }
        }

        /// <summary>
        /// Label do botão Delete de Module
        /// </summary>
        public static string ModuleDeleteButton
        {
            get
            {
                return Localize("Excluir Module");
            }
        }

        /// <summary>
        /// Titulo do index de News
        /// </summary>
        public static string NewsIndexTitle
        {
            get
            {
                return Localize("News");
            }
        }

        /// <summary>
        /// Titulo do Create de News
        /// </summary>
        public static string NewsCreateTitle
        {
            get
            {
                return Localize("Cadastro de News");
            }
        }

        /// <summary>
        /// Titulo do Edit de News
        /// </summary>
        public static string NewsEditTitle
        {
            get
            {
                return Localize("Edição de News");
            }
        }

        /// <summary>
        /// Label do botão Create de News
        /// </summary>
        public static string NewsCreateButton
        {
            get
            {
                return Localize("Novo News");
            }
        }

        /// <summary>
        /// Label do botão Delete de News
        /// </summary>
        public static string NewsDeleteButton
        {
            get
            {
                return Localize("Excluir News");
            }
        }

        /// <summary>
        /// Titulo do index de NewsArea
        /// </summary>
        public static string NewsAreaIndexTitle
        {
            get
            {
                return Localize("NewsArea");
            }
        }

        /// <summary>
        /// Titulo do Create de NewsArea
        /// </summary>
        public static string NewsAreaCreateTitle
        {
            get
            {
                return Localize("Cadastro de NewsArea");
            }
        }

        /// <summary>
        /// Titulo do Edit de NewsArea
        /// </summary>
        public static string NewsAreaEditTitle
        {
            get
            {
                return Localize("Edição de NewsArea");
            }
        }

        /// <summary>
        /// Label do botão Create de NewsArea
        /// </summary>
        public static string NewsAreaCreateButton
        {
            get
            {
                return Localize("Novo NewsArea");
            }
        }

        /// <summary>
        /// Label do botão Delete de NewsArea
        /// </summary>
        public static string NewsAreaDeleteButton
        {
            get
            {
                return Localize("Excluir NewsArea");
            }
        }

        /// <summary>
        /// Titulo do index de NewsCommunity
        /// </summary>
        public static string NewsCommunityIndexTitle
        {
            get
            {
                return Localize("NewsCommunity");
            }
        }

        /// <summary>
        /// Titulo do Create de NewsCommunity
        /// </summary>
        public static string NewsCommunityCreateTitle
        {
            get
            {
                return Localize("Cadastro de NewsCommunity");
            }
        }

        /// <summary>
        /// Titulo do Edit de NewsCommunity
        /// </summary>
        public static string NewsCommunityEditTitle
        {
            get
            {
                return Localize("Edição de NewsCommunity");
            }
        }

        /// <summary>
        /// Label do botão Create de NewsCommunity
        /// </summary>
        public static string NewsCommunityCreateButton
        {
            get
            {
                return Localize("Novo NewsCommunity");
            }
        }

        /// <summary>
        /// Label do botão Delete de NewsCommunity
        /// </summary>
        public static string NewsCommunityDeleteButton
        {
            get
            {
                return Localize("Excluir NewsCommunity");
            }
        }

        /// <summary>
        /// Titulo do index de NewsProfile
        /// </summary>
        public static string NewsProfileIndexTitle
        {
            get
            {
                return Localize("NewsProfile");
            }
        }

        /// <summary>
        /// Titulo do Create de NewsProfile
        /// </summary>
        public static string NewsProfileCreateTitle
        {
            get
            {
                return Localize("Cadastro de NewsProfile");
            }
        }

        /// <summary>
        /// Titulo do Edit de NewsProfile
        /// </summary>
        public static string NewsProfileEditTitle
        {
            get
            {
                return Localize("Edição de NewsProfile");
            }
        }

        /// <summary>
        /// Label do botão Create de NewsProfile
        /// </summary>
        public static string NewsProfileCreateButton
        {
            get
            {
                return Localize("Novo NewsProfile");
            }
        }

        /// <summary>
        /// Label do botão Delete de NewsProfile
        /// </summary>
        public static string NewsProfileDeleteButton
        {
            get
            {
                return Localize("Excluir NewsProfile");
            }
        }

        /// <summary>
        /// Titulo do index de NewsUnit
        /// </summary>
        public static string NewsUnitIndexTitle
        {
            get
            {
                return Localize("NewsUnit");
            }
        }

        /// <summary>
        /// Titulo do Create de NewsUnit
        /// </summary>
        public static string NewsUnitCreateTitle
        {
            get
            {
                return Localize("Cadastro de NewsUnit");
            }
        }

        /// <summary>
        /// Titulo do Edit de NewsUnit
        /// </summary>
        public static string NewsUnitEditTitle
        {
            get
            {
                return Localize("Edição de NewsUnit");
            }
        }

        /// <summary>
        /// Label do botão Create de NewsUnit
        /// </summary>
        public static string NewsUnitCreateButton
        {
            get
            {
                return Localize("Novo NewsUnit");
            }
        }

        /// <summary>
        /// Label do botão Delete de NewsUnit
        /// </summary>
        public static string NewsUnitDeleteButton
        {
            get
            {
                return Localize("Excluir NewsUnit");
            }
        }

        /// <summary>
        /// Titulo do index de NewsCategory
        /// </summary>
        public static string NewsCategoryIndexTitle
        {
            get
            {
                return Localize("NewsCategory");
            }
        }

        /// <summary>
        /// Titulo do Create de NewsCategory
        /// </summary>
        public static string NewsCategoryCreateTitle
        {
            get
            {
                return Localize("Cadastro de NewsCategory");
            }
        }

        /// <summary>
        /// Titulo do Edit de NewsCategory
        /// </summary>
        public static string NewsCategoryEditTitle
        {
            get
            {
                return Localize("Edição de NewsCategory");
            }
        }

        /// <summary>
        /// Label do botão Create de NewsCategory
        /// </summary>
        public static string NewsCategoryCreateButton
        {
            get
            {
                return Localize("Novo NewsCategory");
            }
        }

        /// <summary>
        /// Label do botão Delete de NewsCategory
        /// </summary>
        public static string NewsCategoryDeleteButton
        {
            get
            {
                return Localize("Excluir NewsCategory");
            }
        }

        /// <summary>
        /// Titulo do index de Newsletter
        /// </summary>
        public static string NewsletterIndexTitle
        {
            get
            {
                return Localize("Newsletter");
            }
        }

        /// <summary>
        /// Titulo do Create de Newsletter
        /// </summary>
        public static string NewsletterCreateTitle
        {
            get
            {
                return Localize("Cadastro de Newsletter");
            }
        }

        /// <summary>
        /// Titulo do Edit de Newsletter
        /// </summary>
        public static string NewsletterEditTitle
        {
            get
            {
                return Localize("Edição de Newsletter");
            }
        }

        /// <summary>
        /// Label do botão Create de Newsletter
        /// </summary>
        public static string NewsletterCreateButton
        {
            get
            {
                return Localize("Novo Newsletter");
            }
        }

        /// <summary>
        /// Label do botão Delete de Newsletter
        /// </summary>
        public static string NewsletterDeleteButton
        {
            get
            {
                return Localize("Excluir Newsletter");
            }
        }

        /// <summary>
        /// Titulo do index de Anotação
        /// </summary>
        public static string NoteIndexTitle
        {
            get
            {
                return Localize("Anotação");
            }
        }

        /// <summary>
        /// Titulo do Create de Anotação
        /// </summary>
        public static string NoteCreateTitle
        {
            get
            {
                return Localize("Cadastro de Anotação");
            }
        }

        /// <summary>
        /// Titulo do Edit de Anotação
        /// </summary>
        public static string NoteEditTitle
        {
            get
            {
                return Localize("Edição de Anotação");
            }
        }

        /// <summary>
        /// Label do botão Create de Anotação
        /// </summary>
        public static string NoteCreateButton
        {
            get
            {
                return Localize("Novo Anotação");
            }
        }

        /// <summary>
        /// Label do botão Delete de Anotação
        /// </summary>
        public static string NoteDeleteButton
        {
            get
            {
                return Localize("Excluir Anotação");
            }
        }

        /// <summary>
        /// Titulo do index de Occupation
        /// </summary>
        public static string OccupationIndexTitle
        {
            get
            {
                return Localize("Occupation");
            }
        }

        /// <summary>
        /// Titulo do Create de Occupation
        /// </summary>
        public static string OccupationCreateTitle
        {
            get
            {
                return Localize("Cadastro de Occupation");
            }
        }

        /// <summary>
        /// Titulo do Edit de Occupation
        /// </summary>
        public static string OccupationEditTitle
        {
            get
            {
                return Localize("Edição de Occupation");
            }
        }

        /// <summary>
        /// Label do botão Create de Occupation
        /// </summary>
        public static string OccupationCreateButton
        {
            get
            {
                return Localize("Novo Occupation");
            }
        }

        /// <summary>
        /// Label do botão Delete de Occupation
        /// </summary>
        public static string OccupationDeleteButton
        {
            get
            {
                return Localize("Excluir Occupation");
            }
        }

        /// <summary>
        /// Titulo do index de Avaliação On-Line
        /// </summary>
        public static string OnlineAssessmentIndexTitle
        {
            get
            {
                return Localize("Avaliação On-Line");
            }
        }

        /// <summary>
        /// Titulo do Create de Avaliação On-Line
        /// </summary>
        public static string OnlineAssessmentCreateTitle
        {
            get
            {
                return Localize("Cadastro de Avaliação On-Line");
            }
        }

        /// <summary>
        /// Titulo do Edit de Avaliação On-Line
        /// </summary>
        public static string OnlineAssessmentEditTitle
        {
            get
            {
                return Localize("Edição de Avaliação On-Line");
            }
        }

        /// <summary>
        /// Label do botão Create de Avaliação On-Line
        /// </summary>
        public static string OnlineAssessmentCreateButton
        {
            get
            {
                return Localize("Novo Avaliação On-Line");
            }
        }

        /// <summary>
        /// Label do botão Delete de Avaliação On-Line
        /// </summary>
        public static string OnlineAssessmentDeleteButton
        {
            get
            {
                return Localize("Excluir Avaliação On-Line");
            }
        }

        /// <summary>
        /// Titulo do index de Turma OnLine
        /// </summary>
        public static string OnlineClassIndexTitle
        {
            get
            {
                return Localize("Turma OnLine");
            }
        }

        /// <summary>
        /// Titulo do Create de Turma OnLine
        /// </summary>
        public static string OnlineClassCreateTitle
        {
            get
            {
                return Localize("Cadastro de Turma OnLine");
            }
        }

        /// <summary>
        /// Titulo do Edit de Turma OnLine
        /// </summary>
        public static string OnlineClassEditTitle
        {
            get
            {
                return Localize("Edição de Turma OnLine");
            }
        }

        /// <summary>
        /// Label do botão Create de Turma OnLine
        /// </summary>
        public static string OnlineClassCreateButton
        {
            get
            {
                return Localize("Novo Turma OnLine");
            }
        }

        /// <summary>
        /// Label do botão Delete de Turma OnLine
        /// </summary>
        public static string OnlineClassDeleteButton
        {
            get
            {
                return Localize("Excluir Turma OnLine");
            }
        }

        /// <summary>
        /// Titulo do index de Aula On-Line
        /// </summary>
        public static string OnlineLessonIndexTitle
        {
            get
            {
                return Localize("Aula On-Line");
            }
        }

        /// <summary>
        /// Titulo do Create de Aula On-Line
        /// </summary>
        public static string OnlineLessonCreateTitle
        {
            get
            {
                return Localize("Cadastro de Aula On-Line");
            }
        }

        /// <summary>
        /// Titulo do Edit de Aula On-Line
        /// </summary>
        public static string OnlineLessonEditTitle
        {
            get
            {
                return Localize("Edição de Aula On-Line");
            }
        }

        /// <summary>
        /// Label do botão Create de Aula On-Line
        /// </summary>
        public static string OnlineLessonCreateButton
        {
            get
            {
                return Localize("Novo Aula On-Line");
            }
        }

        /// <summary>
        /// Label do botão Delete de Aula On-Line
        /// </summary>
        public static string OnlineLessonDeleteButton
        {
            get
            {
                return Localize("Excluir Aula On-Line");
            }
        }

        /// <summary>
        /// Titulo do index de Permission
        /// </summary>
        public static string PermissionIndexTitle
        {
            get
            {
                return Localize("Permission");
            }
        }

        /// <summary>
        /// Titulo do Create de Permission
        /// </summary>
        public static string PermissionCreateTitle
        {
            get
            {
                return Localize("Cadastro de Permission");
            }
        }

        /// <summary>
        /// Titulo do Edit de Permission
        /// </summary>
        public static string PermissionEditTitle
        {
            get
            {
                return Localize("Edição de Permission");
            }
        }

        /// <summary>
        /// Label do botão Create de Permission
        /// </summary>
        public static string PermissionCreateButton
        {
            get
            {
                return Localize("Novo Permission");
            }
        }

        /// <summary>
        /// Label do botão Delete de Permission
        /// </summary>
        public static string PermissionDeleteButton
        {
            get
            {
                return Localize("Excluir Permission");
            }
        }

        /// <summary>
        /// Titulo do index de PermissionAccess
        /// </summary>
        public static string PermissionAccessIndexTitle
        {
            get
            {
                return Localize("PermissionAccess");
            }
        }

        /// <summary>
        /// Titulo do Create de PermissionAccess
        /// </summary>
        public static string PermissionAccessCreateTitle
        {
            get
            {
                return Localize("Cadastro de PermissionAccess");
            }
        }

        /// <summary>
        /// Titulo do Edit de PermissionAccess
        /// </summary>
        public static string PermissionAccessEditTitle
        {
            get
            {
                return Localize("Edição de PermissionAccess");
            }
        }

        /// <summary>
        /// Label do botão Create de PermissionAccess
        /// </summary>
        public static string PermissionAccessCreateButton
        {
            get
            {
                return Localize("Novo PermissionAccess");
            }
        }

        /// <summary>
        /// Label do botão Delete de PermissionAccess
        /// </summary>
        public static string PermissionAccessDeleteButton
        {
            get
            {
                return Localize("Excluir PermissionAccess");
            }
        }

        /// <summary>
        /// Titulo do index de PermissionAccessProfile
        /// </summary>
        public static string PermissionAccessProfileIndexTitle
        {
            get
            {
                return Localize("PermissionAccessProfile");
            }
        }

        /// <summary>
        /// Titulo do Create de PermissionAccessProfile
        /// </summary>
        public static string PermissionAccessProfileCreateTitle
        {
            get
            {
                return Localize("Cadastro de PermissionAccessProfile");
            }
        }

        /// <summary>
        /// Titulo do Edit de PermissionAccessProfile
        /// </summary>
        public static string PermissionAccessProfileEditTitle
        {
            get
            {
                return Localize("Edição de PermissionAccessProfile");
            }
        }

        /// <summary>
        /// Label do botão Create de PermissionAccessProfile
        /// </summary>
        public static string PermissionAccessProfileCreateButton
        {
            get
            {
                return Localize("Novo PermissionAccessProfile");
            }
        }

        /// <summary>
        /// Label do botão Delete de PermissionAccessProfile
        /// </summary>
        public static string PermissionAccessProfileDeleteButton
        {
            get
            {
                return Localize("Excluir PermissionAccessProfile");
            }
        }

        /// <summary>
        /// Titulo do index de PermissionAccessUser
        /// </summary>
        public static string PermissionAccessUserIndexTitle
        {
            get
            {
                return Localize("PermissionAccessUser");
            }
        }

        /// <summary>
        /// Titulo do Create de PermissionAccessUser
        /// </summary>
        public static string PermissionAccessUserCreateTitle
        {
            get
            {
                return Localize("Cadastro de PermissionAccessUser");
            }
        }

        /// <summary>
        /// Titulo do Edit de PermissionAccessUser
        /// </summary>
        public static string PermissionAccessUserEditTitle
        {
            get
            {
                return Localize("Edição de PermissionAccessUser");
            }
        }

        /// <summary>
        /// Label do botão Create de PermissionAccessUser
        /// </summary>
        public static string PermissionAccessUserCreateButton
        {
            get
            {
                return Localize("Novo PermissionAccessUser");
            }
        }

        /// <summary>
        /// Label do botão Delete de PermissionAccessUser
        /// </summary>
        public static string PermissionAccessUserDeleteButton
        {
            get
            {
                return Localize("Excluir PermissionAccessUser");
            }
        }

        /// <summary>
        /// Titulo do index de Pré-Requisito
        /// </summary>
        public static string PrerequisiteIndexTitle
        {
            get
            {
                return Localize("Pré-Requisito");
            }
        }

        /// <summary>
        /// Titulo do Create de Pré-Requisito
        /// </summary>
        public static string PrerequisiteCreateTitle
        {
            get
            {
                return Localize("Cadastro de Pré-Requisito");
            }
        }

        /// <summary>
        /// Titulo do Edit de Pré-Requisito
        /// </summary>
        public static string PrerequisiteEditTitle
        {
            get
            {
                return Localize("Edição de Pré-Requisito");
            }
        }

        /// <summary>
        /// Label do botão Create de Pré-Requisito
        /// </summary>
        public static string PrerequisiteCreateButton
        {
            get
            {
                return Localize("Novo Pré-Requisito");
            }
        }

        /// <summary>
        /// Label do botão Delete de Pré-Requisito
        /// </summary>
        public static string PrerequisiteDeleteButton
        {
            get
            {
                return Localize("Excluir Pré-Requisito");
            }
        }

        /// <summary>
        /// Titulo do index de PrerequisiteCourse
        /// </summary>
        public static string PrerequisiteCourseIndexTitle
        {
            get
            {
                return Localize("PrerequisiteCourse");
            }
        }

        /// <summary>
        /// Titulo do Create de PrerequisiteCourse
        /// </summary>
        public static string PrerequisiteCourseCreateTitle
        {
            get
            {
                return Localize("Cadastro de PrerequisiteCourse");
            }
        }

        /// <summary>
        /// Titulo do Edit de PrerequisiteCourse
        /// </summary>
        public static string PrerequisiteCourseEditTitle
        {
            get
            {
                return Localize("Edição de PrerequisiteCourse");
            }
        }

        /// <summary>
        /// Label do botão Create de PrerequisiteCourse
        /// </summary>
        public static string PrerequisiteCourseCreateButton
        {
            get
            {
                return Localize("Novo PrerequisiteCourse");
            }
        }

        /// <summary>
        /// Label do botão Delete de PrerequisiteCourse
        /// </summary>
        public static string PrerequisiteCourseDeleteButton
        {
            get
            {
                return Localize("Excluir PrerequisiteCourse");
            }
        }

        /// <summary>
        /// Titulo do index de Grupo de Pré-Requisitos
        /// </summary>
        public static string PrerequisiteGroupIndexTitle
        {
            get
            {
                return Localize("Grupo de Pré-Requisitos");
            }
        }

        /// <summary>
        /// Titulo do Create de Grupo de Pré-Requisitos
        /// </summary>
        public static string PrerequisiteGroupCreateTitle
        {
            get
            {
                return Localize("Cadastro de Grupo de Pré-Requisitos");
            }
        }

        /// <summary>
        /// Titulo do Edit de Grupo de Pré-Requisitos
        /// </summary>
        public static string PrerequisiteGroupEditTitle
        {
            get
            {
                return Localize("Edição de Grupo de Pré-Requisitos");
            }
        }

        /// <summary>
        /// Label do botão Create de Grupo de Pré-Requisitos
        /// </summary>
        public static string PrerequisiteGroupCreateButton
        {
            get
            {
                return Localize("Novo Grupo de Pré-Requisitos");
            }
        }

        /// <summary>
        /// Label do botão Delete de Grupo de Pré-Requisitos
        /// </summary>
        public static string PrerequisiteGroupDeleteButton
        {
            get
            {
                return Localize("Excluir Grupo de Pré-Requisitos");
            }
        }

        /// <summary>
        /// Titulo do index de PrerequisiteILObjects
        /// </summary>
        public static string PrerequisiteILObjectsIndexTitle
        {
            get
            {
                return Localize("PrerequisiteILObjects");
            }
        }

        /// <summary>
        /// Titulo do Create de PrerequisiteILObjects
        /// </summary>
        public static string PrerequisiteILObjectsCreateTitle
        {
            get
            {
                return Localize("Cadastro de PrerequisiteILObjects");
            }
        }

        /// <summary>
        /// Titulo do Edit de PrerequisiteILObjects
        /// </summary>
        public static string PrerequisiteILObjectsEditTitle
        {
            get
            {
                return Localize("Edição de PrerequisiteILObjects");
            }
        }

        /// <summary>
        /// Label do botão Create de PrerequisiteILObjects
        /// </summary>
        public static string PrerequisiteILObjectsCreateButton
        {
            get
            {
                return Localize("Novo PrerequisiteILObjects");
            }
        }

        /// <summary>
        /// Label do botão Delete de PrerequisiteILObjects
        /// </summary>
        public static string PrerequisiteILObjectsDeleteButton
        {
            get
            {
                return Localize("Excluir PrerequisiteILObjects");
            }
        }

        /// <summary>
        /// Titulo do index de PrerequisiteProgramModule
        /// </summary>
        public static string PrerequisiteProgramModuleIndexTitle
        {
            get
            {
                return Localize("PrerequisiteProgramModule");
            }
        }

        /// <summary>
        /// Titulo do Create de PrerequisiteProgramModule
        /// </summary>
        public static string PrerequisiteProgramModuleCreateTitle
        {
            get
            {
                return Localize("Cadastro de PrerequisiteProgramModule");
            }
        }

        /// <summary>
        /// Titulo do Edit de PrerequisiteProgramModule
        /// </summary>
        public static string PrerequisiteProgramModuleEditTitle
        {
            get
            {
                return Localize("Edição de PrerequisiteProgramModule");
            }
        }

        /// <summary>
        /// Label do botão Create de PrerequisiteProgramModule
        /// </summary>
        public static string PrerequisiteProgramModuleCreateButton
        {
            get
            {
                return Localize("Novo PrerequisiteProgramModule");
            }
        }

        /// <summary>
        /// Label do botão Delete de PrerequisiteProgramModule
        /// </summary>
        public static string PrerequisiteProgramModuleDeleteButton
        {
            get
            {
                return Localize("Excluir PrerequisiteProgramModule");
            }
        }

        /// <summary>
        /// Titulo do index de Impressão Avaliação
        /// </summary>
        public static string PrintedAssessmentIndexTitle
        {
            get
            {
                return Localize("Impressão Avaliação");
            }
        }

        /// <summary>
        /// Titulo do Create de Impressão Avaliação
        /// </summary>
        public static string PrintedAssessmentCreateTitle
        {
            get
            {
                return Localize("Cadastro de Impressão Avaliação");
            }
        }

        /// <summary>
        /// Titulo do Edit de Impressão Avaliação
        /// </summary>
        public static string PrintedAssessmentEditTitle
        {
            get
            {
                return Localize("Edição de Impressão Avaliação");
            }
        }

        /// <summary>
        /// Label do botão Create de Impressão Avaliação
        /// </summary>
        public static string PrintedAssessmentCreateButton
        {
            get
            {
                return Localize("Novo Impressão Avaliação");
            }
        }

        /// <summary>
        /// Label do botão Delete de Impressão Avaliação
        /// </summary>
        public static string PrintedAssessmentDeleteButton
        {
            get
            {
                return Localize("Excluir Impressão Avaliação");
            }
        }

        /// <summary>
        /// Titulo do index de Profile
        /// </summary>
        public static string ProfileIndexTitle
        {
            get
            {
                return Localize("Profile");
            }
        }

        /// <summary>
        /// Titulo do Create de Profile
        /// </summary>
        public static string ProfileCreateTitle
        {
            get
            {
                return Localize("Cadastro de Profile");
            }
        }

        /// <summary>
        /// Titulo do Edit de Profile
        /// </summary>
        public static string ProfileEditTitle
        {
            get
            {
                return Localize("Edição de Profile");
            }
        }

        /// <summary>
        /// Label do botão Create de Profile
        /// </summary>
        public static string ProfileCreateButton
        {
            get
            {
                return Localize("Novo Profile");
            }
        }

        /// <summary>
        /// Label do botão Delete de Profile
        /// </summary>
        public static string ProfileDeleteButton
        {
            get
            {
                return Localize("Excluir Profile");
            }
        }

        /// <summary>
        /// Titulo do index de ProfileProfileProperty
        /// </summary>
        public static string ProfileProfilePropertyIndexTitle
        {
            get
            {
                return Localize("ProfileProfileProperty");
            }
        }

        /// <summary>
        /// Titulo do Create de ProfileProfileProperty
        /// </summary>
        public static string ProfileProfilePropertyCreateTitle
        {
            get
            {
                return Localize("Cadastro de ProfileProfileProperty");
            }
        }

        /// <summary>
        /// Titulo do Edit de ProfileProfileProperty
        /// </summary>
        public static string ProfileProfilePropertyEditTitle
        {
            get
            {
                return Localize("Edição de ProfileProfileProperty");
            }
        }

        /// <summary>
        /// Label do botão Create de ProfileProfileProperty
        /// </summary>
        public static string ProfileProfilePropertyCreateButton
        {
            get
            {
                return Localize("Novo ProfileProfileProperty");
            }
        }

        /// <summary>
        /// Label do botão Delete de ProfileProfileProperty
        /// </summary>
        public static string ProfileProfilePropertyDeleteButton
        {
            get
            {
                return Localize("Excluir ProfileProfileProperty");
            }
        }

        /// <summary>
        /// Titulo do index de ProfileUser
        /// </summary>
        public static string ProfileUserIndexTitle
        {
            get
            {
                return Localize("ProfileUser");
            }
        }

        /// <summary>
        /// Titulo do Create de ProfileUser
        /// </summary>
        public static string ProfileUserCreateTitle
        {
            get
            {
                return Localize("Cadastro de ProfileUser");
            }
        }

        /// <summary>
        /// Titulo do Edit de ProfileUser
        /// </summary>
        public static string ProfileUserEditTitle
        {
            get
            {
                return Localize("Edição de ProfileUser");
            }
        }

        /// <summary>
        /// Label do botão Create de ProfileUser
        /// </summary>
        public static string ProfileUserCreateButton
        {
            get
            {
                return Localize("Novo ProfileUser");
            }
        }

        /// <summary>
        /// Label do botão Delete de ProfileUser
        /// </summary>
        public static string ProfileUserDeleteButton
        {
            get
            {
                return Localize("Excluir ProfileUser");
            }
        }

        /// <summary>
        /// Titulo do index de ProfileProperty
        /// </summary>
        public static string ProfilePropertyIndexTitle
        {
            get
            {
                return Localize("ProfileProperty");
            }
        }

        /// <summary>
        /// Titulo do Create de ProfileProperty
        /// </summary>
        public static string ProfilePropertyCreateTitle
        {
            get
            {
                return Localize("Cadastro de ProfileProperty");
            }
        }

        /// <summary>
        /// Titulo do Edit de ProfileProperty
        /// </summary>
        public static string ProfilePropertyEditTitle
        {
            get
            {
                return Localize("Edição de ProfileProperty");
            }
        }

        /// <summary>
        /// Label do botão Create de ProfileProperty
        /// </summary>
        public static string ProfilePropertyCreateButton
        {
            get
            {
                return Localize("Novo ProfileProperty");
            }
        }

        /// <summary>
        /// Label do botão Delete de ProfileProperty
        /// </summary>
        public static string ProfilePropertyDeleteButton
        {
            get
            {
                return Localize("Excluir ProfileProperty");
            }
        }

        /// <summary>
        /// Titulo do index de Programa
        /// </summary>
        public static string ProgramIndexTitle
        {
            get
            {
                return Localize("Programa");
            }
        }

        /// <summary>
        /// Titulo do Create de Programa
        /// </summary>
        public static string ProgramCreateTitle
        {
            get
            {
                return Localize("Cadastro de Programa");
            }
        }

        /// <summary>
        /// Titulo do Edit de Programa
        /// </summary>
        public static string ProgramEditTitle
        {
            get
            {
                return Localize("Edição de Programa");
            }
        }

        /// <summary>
        /// Label do botão Create de Programa
        /// </summary>
        public static string ProgramCreateButton
        {
            get
            {
                return Localize("Novo Programa");
            }
        }

        /// <summary>
        /// Label do botão Delete de Programa
        /// </summary>
        public static string ProgramDeleteButton
        {
            get
            {
                return Localize("Excluir Programa");
            }
        }

        /// <summary>
        /// Titulo do index de ProgramMedia
        /// </summary>
        public static string ProgramMediaIndexTitle
        {
            get
            {
                return Localize("ProgramMedia");
            }
        }

        /// <summary>
        /// Titulo do Create de ProgramMedia
        /// </summary>
        public static string ProgramMediaCreateTitle
        {
            get
            {
                return Localize("Cadastro de ProgramMedia");
            }
        }

        /// <summary>
        /// Titulo do Edit de ProgramMedia
        /// </summary>
        public static string ProgramMediaEditTitle
        {
            get
            {
                return Localize("Edição de ProgramMedia");
            }
        }

        /// <summary>
        /// Label do botão Create de ProgramMedia
        /// </summary>
        public static string ProgramMediaCreateButton
        {
            get
            {
                return Localize("Novo ProgramMedia");
            }
        }

        /// <summary>
        /// Label do botão Delete de ProgramMedia
        /// </summary>
        public static string ProgramMediaDeleteButton
        {
            get
            {
                return Localize("Excluir ProgramMedia");
            }
        }

        /// <summary>
        /// Titulo do index de ProgramProgramModule
        /// </summary>
        public static string ProgramProgramModuleIndexTitle
        {
            get
            {
                return Localize("ProgramProgramModule");
            }
        }

        /// <summary>
        /// Titulo do Create de ProgramProgramModule
        /// </summary>
        public static string ProgramProgramModuleCreateTitle
        {
            get
            {
                return Localize("Cadastro de ProgramProgramModule");
            }
        }

        /// <summary>
        /// Titulo do Edit de ProgramProgramModule
        /// </summary>
        public static string ProgramProgramModuleEditTitle
        {
            get
            {
                return Localize("Edição de ProgramProgramModule");
            }
        }

        /// <summary>
        /// Label do botão Create de ProgramProgramModule
        /// </summary>
        public static string ProgramProgramModuleCreateButton
        {
            get
            {
                return Localize("Novo ProgramProgramModule");
            }
        }

        /// <summary>
        /// Label do botão Delete de ProgramProgramModule
        /// </summary>
        public static string ProgramProgramModuleDeleteButton
        {
            get
            {
                return Localize("Excluir ProgramProgramModule");
            }
        }

        /// <summary>
        /// Titulo do index de Módulo de Programa
        /// </summary>
        public static string ProgramModuleIndexTitle
        {
            get
            {
                return Localize("Módulo de Programa");
            }
        }

        /// <summary>
        /// Titulo do Create de Módulo de Programa
        /// </summary>
        public static string ProgramModuleCreateTitle
        {
            get
            {
                return Localize("Cadastro de Módulo de Programa");
            }
        }

        /// <summary>
        /// Titulo do Edit de Módulo de Programa
        /// </summary>
        public static string ProgramModuleEditTitle
        {
            get
            {
                return Localize("Edição de Módulo de Programa");
            }
        }

        /// <summary>
        /// Label do botão Create de Módulo de Programa
        /// </summary>
        public static string ProgramModuleCreateButton
        {
            get
            {
                return Localize("Novo Módulo de Programa");
            }
        }

        /// <summary>
        /// Label do botão Delete de Módulo de Programa
        /// </summary>
        public static string ProgramModuleDeleteButton
        {
            get
            {
                return Localize("Excluir Módulo de Programa");
            }
        }

        /// <summary>
        /// Titulo do index de PropertyList
        /// </summary>
        public static string PropertyListIndexTitle
        {
            get
            {
                return Localize("PropertyList");
            }
        }

        /// <summary>
        /// Titulo do Create de PropertyList
        /// </summary>
        public static string PropertyListCreateTitle
        {
            get
            {
                return Localize("Cadastro de PropertyList");
            }
        }

        /// <summary>
        /// Titulo do Edit de PropertyList
        /// </summary>
        public static string PropertyListEditTitle
        {
            get
            {
                return Localize("Edição de PropertyList");
            }
        }

        /// <summary>
        /// Label do botão Create de PropertyList
        /// </summary>
        public static string PropertyListCreateButton
        {
            get
            {
                return Localize("Novo PropertyList");
            }
        }

        /// <summary>
        /// Label do botão Delete de PropertyList
        /// </summary>
        public static string PropertyListDeleteButton
        {
            get
            {
                return Localize("Excluir PropertyList");
            }
        }

        /// <summary>
        /// Titulo do index de PropertyLog
        /// </summary>
        public static string PropertyLogIndexTitle
        {
            get
            {
                return Localize("PropertyLog");
            }
        }

        /// <summary>
        /// Titulo do Create de PropertyLog
        /// </summary>
        public static string PropertyLogCreateTitle
        {
            get
            {
                return Localize("Cadastro de PropertyLog");
            }
        }

        /// <summary>
        /// Titulo do Edit de PropertyLog
        /// </summary>
        public static string PropertyLogEditTitle
        {
            get
            {
                return Localize("Edição de PropertyLog");
            }
        }

        /// <summary>
        /// Label do botão Create de PropertyLog
        /// </summary>
        public static string PropertyLogCreateButton
        {
            get
            {
                return Localize("Novo PropertyLog");
            }
        }

        /// <summary>
        /// Label do botão Delete de PropertyLog
        /// </summary>
        public static string PropertyLogDeleteButton
        {
            get
            {
                return Localize("Excluir PropertyLog");
            }
        }

        /// <summary>
        /// Titulo do index de TentativaQuestão
        /// </summary>
        public static string QuestionAttemptsIndexTitle
        {
            get
            {
                return Localize("TentativaQuestão");
            }
        }

        /// <summary>
        /// Titulo do Create de TentativaQuestão
        /// </summary>
        public static string QuestionAttemptsCreateTitle
        {
            get
            {
                return Localize("Cadastro de TentativaQuestão");
            }
        }

        /// <summary>
        /// Titulo do Edit de TentativaQuestão
        /// </summary>
        public static string QuestionAttemptsEditTitle
        {
            get
            {
                return Localize("Edição de TentativaQuestão");
            }
        }

        /// <summary>
        /// Label do botão Create de TentativaQuestão
        /// </summary>
        public static string QuestionAttemptsCreateButton
        {
            get
            {
                return Localize("Novo TentativaQuestão");
            }
        }

        /// <summary>
        /// Label do botão Delete de TentativaQuestão
        /// </summary>
        public static string QuestionAttemptsDeleteButton
        {
            get
            {
                return Localize("Excluir TentativaQuestão");
            }
        }

        /// <summary>
        /// Titulo do index de Questão Categoria
        /// </summary>
        public static string QuestionCategoryIndexTitle
        {
            get
            {
                return Localize("Questão Categoria");
            }
        }

        /// <summary>
        /// Titulo do Create de Questão Categoria
        /// </summary>
        public static string QuestionCategoryCreateTitle
        {
            get
            {
                return Localize("Cadastro de Questão Categoria");
            }
        }

        /// <summary>
        /// Titulo do Edit de Questão Categoria
        /// </summary>
        public static string QuestionCategoryEditTitle
        {
            get
            {
                return Localize("Edição de Questão Categoria");
            }
        }

        /// <summary>
        /// Label do botão Create de Questão Categoria
        /// </summary>
        public static string QuestionCategoryCreateButton
        {
            get
            {
                return Localize("Novo Questão Categoria");
            }
        }

        /// <summary>
        /// Label do botão Delete de Questão Categoria
        /// </summary>
        public static string QuestionCategoryDeleteButton
        {
            get
            {
                return Localize("Excluir Questão Categoria");
            }
        }

        /// <summary>
        /// Titulo do index de Alternativa Questão
        /// </summary>
        public static string QuestionItemIndexTitle
        {
            get
            {
                return Localize("Alternativa Questão");
            }
        }

        /// <summary>
        /// Titulo do Create de Alternativa Questão
        /// </summary>
        public static string QuestionItemCreateTitle
        {
            get
            {
                return Localize("Cadastro de Alternativa Questão");
            }
        }

        /// <summary>
        /// Titulo do Edit de Alternativa Questão
        /// </summary>
        public static string QuestionItemEditTitle
        {
            get
            {
                return Localize("Edição de Alternativa Questão");
            }
        }

        /// <summary>
        /// Label do botão Create de Alternativa Questão
        /// </summary>
        public static string QuestionItemCreateButton
        {
            get
            {
                return Localize("Novo Alternativa Questão");
            }
        }

        /// <summary>
        /// Label do botão Delete de Alternativa Questão
        /// </summary>
        public static string QuestionItemDeleteButton
        {
            get
            {
                return Localize("Excluir Alternativa Questão");
            }
        }

        /// <summary>
        /// Titulo do index de Escala Likert
        /// </summary>
        public static string QuestionLikertScaleIndexTitle
        {
            get
            {
                return Localize("Escala Likert");
            }
        }

        /// <summary>
        /// Titulo do Create de Escala Likert
        /// </summary>
        public static string QuestionLikertScaleCreateTitle
        {
            get
            {
                return Localize("Cadastro de Escala Likert");
            }
        }

        /// <summary>
        /// Titulo do Edit de Escala Likert
        /// </summary>
        public static string QuestionLikertScaleEditTitle
        {
            get
            {
                return Localize("Edição de Escala Likert");
            }
        }

        /// <summary>
        /// Label do botão Create de Escala Likert
        /// </summary>
        public static string QuestionLikertScaleCreateButton
        {
            get
            {
                return Localize("Novo Escala Likert");
            }
        }

        /// <summary>
        /// Label do botão Delete de Escala Likert
        /// </summary>
        public static string QuestionLikertScaleDeleteButton
        {
            get
            {
                return Localize("Excluir Escala Likert");
            }
        }

        /// <summary>
        /// Titulo do index de Grupo Escala Likert
        /// </summary>
        public static string QuestionLikertScaleGroupIndexTitle
        {
            get
            {
                return Localize("Grupo Escala Likert");
            }
        }

        /// <summary>
        /// Titulo do Create de Grupo Escala Likert
        /// </summary>
        public static string QuestionLikertScaleGroupCreateTitle
        {
            get
            {
                return Localize("Cadastro de Grupo Escala Likert");
            }
        }

        /// <summary>
        /// Titulo do Edit de Grupo Escala Likert
        /// </summary>
        public static string QuestionLikertScaleGroupEditTitle
        {
            get
            {
                return Localize("Edição de Grupo Escala Likert");
            }
        }

        /// <summary>
        /// Label do botão Create de Grupo Escala Likert
        /// </summary>
        public static string QuestionLikertScaleGroupCreateButton
        {
            get
            {
                return Localize("Novo Grupo Escala Likert");
            }
        }

        /// <summary>
        /// Label do botão Delete de Grupo Escala Likert
        /// </summary>
        public static string QuestionLikertScaleGroupDeleteButton
        {
            get
            {
                return Localize("Excluir Grupo Escala Likert");
            }
        }

        /// <summary>
        /// Titulo do index de Frequência
        /// </summary>
        public static string RecurrenceIndexTitle
        {
            get
            {
                return Localize("Frequência");
            }
        }

        /// <summary>
        /// Titulo do Create de Frequência
        /// </summary>
        public static string RecurrenceCreateTitle
        {
            get
            {
                return Localize("Cadastro de Frequência");
            }
        }

        /// <summary>
        /// Titulo do Edit de Frequência
        /// </summary>
        public static string RecurrenceEditTitle
        {
            get
            {
                return Localize("Edição de Frequência");
            }
        }

        /// <summary>
        /// Label do botão Create de Frequência
        /// </summary>
        public static string RecurrenceCreateButton
        {
            get
            {
                return Localize("Novo Frequência");
            }
        }

        /// <summary>
        /// Label do botão Delete de Frequência
        /// </summary>
        public static string RecurrenceDeleteButton
        {
            get
            {
                return Localize("Excluir Frequência");
            }
        }

        /// <summary>
        /// Titulo do index de Region
        /// </summary>
        public static string RegionIndexTitle
        {
            get
            {
                return Localize("Region");
            }
        }

        /// <summary>
        /// Titulo do Create de Region
        /// </summary>
        public static string RegionCreateTitle
        {
            get
            {
                return Localize("Cadastro de Region");
            }
        }

        /// <summary>
        /// Titulo do Edit de Region
        /// </summary>
        public static string RegionEditTitle
        {
            get
            {
                return Localize("Edição de Region");
            }
        }

        /// <summary>
        /// Label do botão Create de Region
        /// </summary>
        public static string RegionCreateButton
        {
            get
            {
                return Localize("Novo Region");
            }
        }

        /// <summary>
        /// Label do botão Delete de Region
        /// </summary>
        public static string RegionDeleteButton
        {
            get
            {
                return Localize("Excluir Region");
            }
        }

        /// <summary>
        /// Titulo do index de ReleaseCertificate
        /// </summary>
        public static string ReleaseCertificateIndexTitle
        {
            get
            {
                return Localize("ReleaseCertificate");
            }
        }

        /// <summary>
        /// Titulo do Create de ReleaseCertificate
        /// </summary>
        public static string ReleaseCertificateCreateTitle
        {
            get
            {
                return Localize("Cadastro de ReleaseCertificate");
            }
        }

        /// <summary>
        /// Titulo do Edit de ReleaseCertificate
        /// </summary>
        public static string ReleaseCertificateEditTitle
        {
            get
            {
                return Localize("Edição de ReleaseCertificate");
            }
        }

        /// <summary>
        /// Label do botão Create de ReleaseCertificate
        /// </summary>
        public static string ReleaseCertificateCreateButton
        {
            get
            {
                return Localize("Novo ReleaseCertificate");
            }
        }

        /// <summary>
        /// Label do botão Delete de ReleaseCertificate
        /// </summary>
        public static string ReleaseCertificateDeleteButton
        {
            get
            {
                return Localize("Excluir ReleaseCertificate");
            }
        }

        /// <summary>
        /// Titulo do index de ResumeCourse
        /// </summary>
        public static string ResumeCourseIndexTitle
        {
            get
            {
                return Localize("ResumeCourse");
            }
        }

        /// <summary>
        /// Titulo do Create de ResumeCourse
        /// </summary>
        public static string ResumeCourseCreateTitle
        {
            get
            {
                return Localize("Cadastro de ResumeCourse");
            }
        }

        /// <summary>
        /// Titulo do Edit de ResumeCourse
        /// </summary>
        public static string ResumeCourseEditTitle
        {
            get
            {
                return Localize("Edição de ResumeCourse");
            }
        }

        /// <summary>
        /// Label do botão Create de ResumeCourse
        /// </summary>
        public static string ResumeCourseCreateButton
        {
            get
            {
                return Localize("Novo ResumeCourse");
            }
        }

        /// <summary>
        /// Label do botão Delete de ResumeCourse
        /// </summary>
        public static string ResumeCourseDeleteButton
        {
            get
            {
                return Localize("Excluir ResumeCourse");
            }
        }

        /// <summary>
        /// Titulo do index de Órgão / Setor
        /// </summary>
        public static string SectionIndexTitle
        {
            get
            {
                return Localize("Órgão / Setor");
            }
        }

        /// <summary>
        /// Titulo do Create de Órgão / Setor
        /// </summary>
        public static string SectionCreateTitle
        {
            get
            {
                return Localize("Cadastro de Órgão / Setor");
            }
        }

        /// <summary>
        /// Titulo do Edit de Órgão / Setor
        /// </summary>
        public static string SectionEditTitle
        {
            get
            {
                return Localize("Edição de Órgão / Setor");
            }
        }

        /// <summary>
        /// Label do botão Create de Órgão / Setor
        /// </summary>
        public static string SectionCreateButton
        {
            get
            {
                return Localize("Novo Órgão / Setor");
            }
        }

        /// <summary>
        /// Label do botão Delete de Órgão / Setor
        /// </summary>
        public static string SectionDeleteButton
        {
            get
            {
                return Localize("Excluir Órgão / Setor");
            }
        }

        /// <summary>
        /// Titulo do index de SentNewsletter
        /// </summary>
        public static string SentNewsletterIndexTitle
        {
            get
            {
                return Localize("SentNewsletter");
            }
        }

        /// <summary>
        /// Titulo do Create de SentNewsletter
        /// </summary>
        public static string SentNewsletterCreateTitle
        {
            get
            {
                return Localize("Cadastro de SentNewsletter");
            }
        }

        /// <summary>
        /// Titulo do Edit de SentNewsletter
        /// </summary>
        public static string SentNewsletterEditTitle
        {
            get
            {
                return Localize("Edição de SentNewsletter");
            }
        }

        /// <summary>
        /// Label do botão Create de SentNewsletter
        /// </summary>
        public static string SentNewsletterCreateButton
        {
            get
            {
                return Localize("Novo SentNewsletter");
            }
        }

        /// <summary>
        /// Label do botão Delete de SentNewsletter
        /// </summary>
        public static string SentNewsletterDeleteButton
        {
            get
            {
                return Localize("Excluir SentNewsletter");
            }
        }

        /// <summary>
        /// Titulo do index de Service
        /// </summary>
        public static string ServiceIndexTitle
        {
            get
            {
                return Localize("Service");
            }
        }

        /// <summary>
        /// Titulo do Create de Service
        /// </summary>
        public static string ServiceCreateTitle
        {
            get
            {
                return Localize("Cadastro de Service");
            }
        }

        /// <summary>
        /// Titulo do Edit de Service
        /// </summary>
        public static string ServiceEditTitle
        {
            get
            {
                return Localize("Edição de Service");
            }
        }

        /// <summary>
        /// Label do botão Create de Service
        /// </summary>
        public static string ServiceCreateButton
        {
            get
            {
                return Localize("Novo Service");
            }
        }

        /// <summary>
        /// Label do botão Delete de Service
        /// </summary>
        public static string ServiceDeleteButton
        {
            get
            {
                return Localize("Excluir Service");
            }
        }

        /// <summary>
        /// Titulo do index de ServiceProvider
        /// </summary>
        public static string ServiceProviderIndexTitle
        {
            get
            {
                return Localize("ServiceProvider");
            }
        }

        /// <summary>
        /// Titulo do Create de ServiceProvider
        /// </summary>
        public static string ServiceProviderCreateTitle
        {
            get
            {
                return Localize("Cadastro de ServiceProvider");
            }
        }

        /// <summary>
        /// Titulo do Edit de ServiceProvider
        /// </summary>
        public static string ServiceProviderEditTitle
        {
            get
            {
                return Localize("Edição de ServiceProvider");
            }
        }

        /// <summary>
        /// Label do botão Create de ServiceProvider
        /// </summary>
        public static string ServiceProviderCreateButton
        {
            get
            {
                return Localize("Novo ServiceProvider");
            }
        }

        /// <summary>
        /// Label do botão Delete de ServiceProvider
        /// </summary>
        public static string ServiceProviderDeleteButton
        {
            get
            {
                return Localize("Excluir ServiceProvider");
            }
        }

        /// <summary>
        /// Titulo do index de ServiceProviderBank
        /// </summary>
        public static string ServiceProviderBankIndexTitle
        {
            get
            {
                return Localize("ServiceProviderBank");
            }
        }

        /// <summary>
        /// Titulo do Create de ServiceProviderBank
        /// </summary>
        public static string ServiceProviderBankCreateTitle
        {
            get
            {
                return Localize("Cadastro de ServiceProviderBank");
            }
        }

        /// <summary>
        /// Titulo do Edit de ServiceProviderBank
        /// </summary>
        public static string ServiceProviderBankEditTitle
        {
            get
            {
                return Localize("Edição de ServiceProviderBank");
            }
        }

        /// <summary>
        /// Label do botão Create de ServiceProviderBank
        /// </summary>
        public static string ServiceProviderBankCreateButton
        {
            get
            {
                return Localize("Novo ServiceProviderBank");
            }
        }

        /// <summary>
        /// Label do botão Delete de ServiceProviderBank
        /// </summary>
        public static string ServiceProviderBankDeleteButton
        {
            get
            {
                return Localize("Excluir ServiceProviderBank");
            }
        }

        /// <summary>
        /// Titulo do index de SocialMember
        /// </summary>
        public static string SocialMemberIndexTitle
        {
            get
            {
                return Localize("SocialMember");
            }
        }

        /// <summary>
        /// Titulo do Create de SocialMember
        /// </summary>
        public static string SocialMemberCreateTitle
        {
            get
            {
                return Localize("Cadastro de SocialMember");
            }
        }

        /// <summary>
        /// Titulo do Edit de SocialMember
        /// </summary>
        public static string SocialMemberEditTitle
        {
            get
            {
                return Localize("Edição de SocialMember");
            }
        }

        /// <summary>
        /// Label do botão Create de SocialMember
        /// </summary>
        public static string SocialMemberCreateButton
        {
            get
            {
                return Localize("Novo SocialMember");
            }
        }

        /// <summary>
        /// Label do botão Delete de SocialMember
        /// </summary>
        public static string SocialMemberDeleteButton
        {
            get
            {
                return Localize("Excluir SocialMember");
            }
        }

        /// <summary>
        /// Titulo do index de SocialNetwork
        /// </summary>
        public static string SocialNetworkIndexTitle
        {
            get
            {
                return Localize("SocialNetwork");
            }
        }

        /// <summary>
        /// Titulo do Create de SocialNetwork
        /// </summary>
        public static string SocialNetworkCreateTitle
        {
            get
            {
                return Localize("Cadastro de SocialNetwork");
            }
        }

        /// <summary>
        /// Titulo do Edit de SocialNetwork
        /// </summary>
        public static string SocialNetworkEditTitle
        {
            get
            {
                return Localize("Edição de SocialNetwork");
            }
        }

        /// <summary>
        /// Label do botão Create de SocialNetwork
        /// </summary>
        public static string SocialNetworkCreateButton
        {
            get
            {
                return Localize("Novo SocialNetwork");
            }
        }

        /// <summary>
        /// Label do botão Delete de SocialNetwork
        /// </summary>
        public static string SocialNetworkDeleteButton
        {
            get
            {
                return Localize("Excluir SocialNetwork");
            }
        }

        /// <summary>
        /// Titulo do index de SpecialAssessment
        /// </summary>
        public static string SpecialAssessmentIndexTitle
        {
            get
            {
                return Localize("SpecialAssessment");
            }
        }

        /// <summary>
        /// Titulo do Create de SpecialAssessment
        /// </summary>
        public static string SpecialAssessmentCreateTitle
        {
            get
            {
                return Localize("Cadastro de SpecialAssessment");
            }
        }

        /// <summary>
        /// Titulo do Edit de SpecialAssessment
        /// </summary>
        public static string SpecialAssessmentEditTitle
        {
            get
            {
                return Localize("Edição de SpecialAssessment");
            }
        }

        /// <summary>
        /// Label do botão Create de SpecialAssessment
        /// </summary>
        public static string SpecialAssessmentCreateButton
        {
            get
            {
                return Localize("Novo SpecialAssessment");
            }
        }

        /// <summary>
        /// Label do botão Delete de SpecialAssessment
        /// </summary>
        public static string SpecialAssessmentDeleteButton
        {
            get
            {
                return Localize("Excluir SpecialAssessment");
            }
        }

        /// <summary>
        /// Titulo do index de State
        /// </summary>
        public static string StateIndexTitle
        {
            get
            {
                return Localize("State");
            }
        }

        /// <summary>
        /// Titulo do Create de State
        /// </summary>
        public static string StateCreateTitle
        {
            get
            {
                return Localize("Cadastro de State");
            }
        }

        /// <summary>
        /// Titulo do Edit de State
        /// </summary>
        public static string StateEditTitle
        {
            get
            {
                return Localize("Edição de State");
            }
        }

        /// <summary>
        /// Label do botão Create de State
        /// </summary>
        public static string StateCreateButton
        {
            get
            {
                return Localize("Novo State");
            }
        }

        /// <summary>
        /// Label do botão Delete de State
        /// </summary>
        public static string StateDeleteButton
        {
            get
            {
                return Localize("Excluir State");
            }
        }

        /// <summary>
        /// Titulo do index de Survey
        /// </summary>
        public static string SurveyIndexTitle
        {
            get
            {
                return Localize("Survey");
            }
        }

        /// <summary>
        /// Titulo do Create de Survey
        /// </summary>
        public static string SurveyCreateTitle
        {
            get
            {
                return Localize("Cadastro de Survey");
            }
        }

        /// <summary>
        /// Titulo do Edit de Survey
        /// </summary>
        public static string SurveyEditTitle
        {
            get
            {
                return Localize("Edição de Survey");
            }
        }

        /// <summary>
        /// Label do botão Create de Survey
        /// </summary>
        public static string SurveyCreateButton
        {
            get
            {
                return Localize("Novo Survey");
            }
        }

        /// <summary>
        /// Label do botão Delete de Survey
        /// </summary>
        public static string SurveyDeleteButton
        {
            get
            {
                return Localize("Excluir Survey");
            }
        }

        /// <summary>
        /// Titulo do index de SurveyArea
        /// </summary>
        public static string SurveyAreaIndexTitle
        {
            get
            {
                return Localize("SurveyArea");
            }
        }

        /// <summary>
        /// Titulo do Create de SurveyArea
        /// </summary>
        public static string SurveyAreaCreateTitle
        {
            get
            {
                return Localize("Cadastro de SurveyArea");
            }
        }

        /// <summary>
        /// Titulo do Edit de SurveyArea
        /// </summary>
        public static string SurveyAreaEditTitle
        {
            get
            {
                return Localize("Edição de SurveyArea");
            }
        }

        /// <summary>
        /// Label do botão Create de SurveyArea
        /// </summary>
        public static string SurveyAreaCreateButton
        {
            get
            {
                return Localize("Novo SurveyArea");
            }
        }

        /// <summary>
        /// Label do botão Delete de SurveyArea
        /// </summary>
        public static string SurveyAreaDeleteButton
        {
            get
            {
                return Localize("Excluir SurveyArea");
            }
        }

        /// <summary>
        /// Titulo do index de SurveyClass
        /// </summary>
        public static string SurveyClassIndexTitle
        {
            get
            {
                return Localize("SurveyClass");
            }
        }

        /// <summary>
        /// Titulo do Create de SurveyClass
        /// </summary>
        public static string SurveyClassCreateTitle
        {
            get
            {
                return Localize("Cadastro de SurveyClass");
            }
        }

        /// <summary>
        /// Titulo do Edit de SurveyClass
        /// </summary>
        public static string SurveyClassEditTitle
        {
            get
            {
                return Localize("Edição de SurveyClass");
            }
        }

        /// <summary>
        /// Label do botão Create de SurveyClass
        /// </summary>
        public static string SurveyClassCreateButton
        {
            get
            {
                return Localize("Novo SurveyClass");
            }
        }

        /// <summary>
        /// Label do botão Delete de SurveyClass
        /// </summary>
        public static string SurveyClassDeleteButton
        {
            get
            {
                return Localize("Excluir SurveyClass");
            }
        }

        /// <summary>
        /// Titulo do index de SurveyCourse
        /// </summary>
        public static string SurveyCourseIndexTitle
        {
            get
            {
                return Localize("SurveyCourse");
            }
        }

        /// <summary>
        /// Titulo do Create de SurveyCourse
        /// </summary>
        public static string SurveyCourseCreateTitle
        {
            get
            {
                return Localize("Cadastro de SurveyCourse");
            }
        }

        /// <summary>
        /// Titulo do Edit de SurveyCourse
        /// </summary>
        public static string SurveyCourseEditTitle
        {
            get
            {
                return Localize("Edição de SurveyCourse");
            }
        }

        /// <summary>
        /// Label do botão Create de SurveyCourse
        /// </summary>
        public static string SurveyCourseCreateButton
        {
            get
            {
                return Localize("Novo SurveyCourse");
            }
        }

        /// <summary>
        /// Label do botão Delete de SurveyCourse
        /// </summary>
        public static string SurveyCourseDeleteButton
        {
            get
            {
                return Localize("Excluir SurveyCourse");
            }
        }

        /// <summary>
        /// Titulo do index de SurveyProfile
        /// </summary>
        public static string SurveyProfileIndexTitle
        {
            get
            {
                return Localize("SurveyProfile");
            }
        }

        /// <summary>
        /// Titulo do Create de SurveyProfile
        /// </summary>
        public static string SurveyProfileCreateTitle
        {
            get
            {
                return Localize("Cadastro de SurveyProfile");
            }
        }

        /// <summary>
        /// Titulo do Edit de SurveyProfile
        /// </summary>
        public static string SurveyProfileEditTitle
        {
            get
            {
                return Localize("Edição de SurveyProfile");
            }
        }

        /// <summary>
        /// Label do botão Create de SurveyProfile
        /// </summary>
        public static string SurveyProfileCreateButton
        {
            get
            {
                return Localize("Novo SurveyProfile");
            }
        }

        /// <summary>
        /// Label do botão Delete de SurveyProfile
        /// </summary>
        public static string SurveyProfileDeleteButton
        {
            get
            {
                return Localize("Excluir SurveyProfile");
            }
        }

        /// <summary>
        /// Titulo do index de SurveyProgram
        /// </summary>
        public static string SurveyProgramIndexTitle
        {
            get
            {
                return Localize("SurveyProgram");
            }
        }

        /// <summary>
        /// Titulo do Create de SurveyProgram
        /// </summary>
        public static string SurveyProgramCreateTitle
        {
            get
            {
                return Localize("Cadastro de SurveyProgram");
            }
        }

        /// <summary>
        /// Titulo do Edit de SurveyProgram
        /// </summary>
        public static string SurveyProgramEditTitle
        {
            get
            {
                return Localize("Edição de SurveyProgram");
            }
        }

        /// <summary>
        /// Label do botão Create de SurveyProgram
        /// </summary>
        public static string SurveyProgramCreateButton
        {
            get
            {
                return Localize("Novo SurveyProgram");
            }
        }

        /// <summary>
        /// Label do botão Delete de SurveyProgram
        /// </summary>
        public static string SurveyProgramDeleteButton
        {
            get
            {
                return Localize("Excluir SurveyProgram");
            }
        }

        /// <summary>
        /// Titulo do index de SurveyUnit
        /// </summary>
        public static string SurveyUnitIndexTitle
        {
            get
            {
                return Localize("SurveyUnit");
            }
        }

        /// <summary>
        /// Titulo do Create de SurveyUnit
        /// </summary>
        public static string SurveyUnitCreateTitle
        {
            get
            {
                return Localize("Cadastro de SurveyUnit");
            }
        }

        /// <summary>
        /// Titulo do Edit de SurveyUnit
        /// </summary>
        public static string SurveyUnitEditTitle
        {
            get
            {
                return Localize("Edição de SurveyUnit");
            }
        }

        /// <summary>
        /// Label do botão Create de SurveyUnit
        /// </summary>
        public static string SurveyUnitCreateButton
        {
            get
            {
                return Localize("Novo SurveyUnit");
            }
        }

        /// <summary>
        /// Label do botão Delete de SurveyUnit
        /// </summary>
        public static string SurveyUnitDeleteButton
        {
            get
            {
                return Localize("Excluir SurveyUnit");
            }
        }

        /// <summary>
        /// Titulo do index de SurveyItem
        /// </summary>
        public static string SurveyItemIndexTitle
        {
            get
            {
                return Localize("SurveyItem");
            }
        }

        /// <summary>
        /// Titulo do Create de SurveyItem
        /// </summary>
        public static string SurveyItemCreateTitle
        {
            get
            {
                return Localize("Cadastro de SurveyItem");
            }
        }

        /// <summary>
        /// Titulo do Edit de SurveyItem
        /// </summary>
        public static string SurveyItemEditTitle
        {
            get
            {
                return Localize("Edição de SurveyItem");
            }
        }

        /// <summary>
        /// Label do botão Create de SurveyItem
        /// </summary>
        public static string SurveyItemCreateButton
        {
            get
            {
                return Localize("Novo SurveyItem");
            }
        }

        /// <summary>
        /// Label do botão Delete de SurveyItem
        /// </summary>
        public static string SurveyItemDeleteButton
        {
            get
            {
                return Localize("Excluir SurveyItem");
            }
        }

        /// <summary>
        /// Titulo do index de SurveyItemAltSurveyUser
        /// </summary>
        public static string SurveyItemAltSurveyUserIndexTitle
        {
            get
            {
                return Localize("SurveyItemAltSurveyUser");
            }
        }

        /// <summary>
        /// Titulo do Create de SurveyItemAltSurveyUser
        /// </summary>
        public static string SurveyItemAltSurveyUserCreateTitle
        {
            get
            {
                return Localize("Cadastro de SurveyItemAltSurveyUser");
            }
        }

        /// <summary>
        /// Titulo do Edit de SurveyItemAltSurveyUser
        /// </summary>
        public static string SurveyItemAltSurveyUserEditTitle
        {
            get
            {
                return Localize("Edição de SurveyItemAltSurveyUser");
            }
        }

        /// <summary>
        /// Label do botão Create de SurveyItemAltSurveyUser
        /// </summary>
        public static string SurveyItemAltSurveyUserCreateButton
        {
            get
            {
                return Localize("Novo SurveyItemAltSurveyUser");
            }
        }

        /// <summary>
        /// Label do botão Delete de SurveyItemAltSurveyUser
        /// </summary>
        public static string SurveyItemAltSurveyUserDeleteButton
        {
            get
            {
                return Localize("Excluir SurveyItemAltSurveyUser");
            }
        }

        /// <summary>
        /// Titulo do index de SurveyItemAlternative
        /// </summary>
        public static string SurveyItemAlternativeIndexTitle
        {
            get
            {
                return Localize("SurveyItemAlternative");
            }
        }

        /// <summary>
        /// Titulo do Create de SurveyItemAlternative
        /// </summary>
        public static string SurveyItemAlternativeCreateTitle
        {
            get
            {
                return Localize("Cadastro de SurveyItemAlternative");
            }
        }

        /// <summary>
        /// Titulo do Edit de SurveyItemAlternative
        /// </summary>
        public static string SurveyItemAlternativeEditTitle
        {
            get
            {
                return Localize("Edição de SurveyItemAlternative");
            }
        }

        /// <summary>
        /// Label do botão Create de SurveyItemAlternative
        /// </summary>
        public static string SurveyItemAlternativeCreateButton
        {
            get
            {
                return Localize("Novo SurveyItemAlternative");
            }
        }

        /// <summary>
        /// Label do botão Delete de SurveyItemAlternative
        /// </summary>
        public static string SurveyItemAlternativeDeleteButton
        {
            get
            {
                return Localize("Excluir SurveyItemAlternative");
            }
        }

        /// <summary>
        /// Titulo do index de SurveyUser
        /// </summary>
        public static string SurveyUserIndexTitle
        {
            get
            {
                return Localize("SurveyUser");
            }
        }

        /// <summary>
        /// Titulo do Create de SurveyUser
        /// </summary>
        public static string SurveyUserCreateTitle
        {
            get
            {
                return Localize("Cadastro de SurveyUser");
            }
        }

        /// <summary>
        /// Titulo do Edit de SurveyUser
        /// </summary>
        public static string SurveyUserEditTitle
        {
            get
            {
                return Localize("Edição de SurveyUser");
            }
        }

        /// <summary>
        /// Label do botão Create de SurveyUser
        /// </summary>
        public static string SurveyUserCreateButton
        {
            get
            {
                return Localize("Novo SurveyUser");
            }
        }

        /// <summary>
        /// Label do botão Delete de SurveyUser
        /// </summary>
        public static string SurveyUserDeleteButton
        {
            get
            {
                return Localize("Excluir SurveyUser");
            }
        }

        /// <summary>
        /// Titulo do index de sysdiagrams
        /// </summary>
        public static string sysdiagramsIndexTitle
        {
            get
            {
                return Localize("sysdiagrams");
            }
        }

        /// <summary>
        /// Titulo do Create de sysdiagrams
        /// </summary>
        public static string sysdiagramsCreateTitle
        {
            get
            {
                return Localize("Cadastro de sysdiagrams");
            }
        }

        /// <summary>
        /// Titulo do Edit de sysdiagrams
        /// </summary>
        public static string sysdiagramsEditTitle
        {
            get
            {
                return Localize("Edição de sysdiagrams");
            }
        }

        /// <summary>
        /// Label do botão Create de sysdiagrams
        /// </summary>
        public static string sysdiagramsCreateButton
        {
            get
            {
                return Localize("Novo sysdiagrams");
            }
        }

        /// <summary>
        /// Label do botão Delete de sysdiagrams
        /// </summary>
        public static string sysdiagramsDeleteButton
        {
            get
            {
                return Localize("Excluir sysdiagrams");
            }
        }

        /// <summary>
        /// Titulo do index de SystemProperty
        /// </summary>
        public static string SystemPropertyIndexTitle
        {
            get
            {
                return Localize("SystemProperty");
            }
        }

        /// <summary>
        /// Titulo do Create de SystemProperty
        /// </summary>
        public static string SystemPropertyCreateTitle
        {
            get
            {
                return Localize("Cadastro de SystemProperty");
            }
        }

        /// <summary>
        /// Titulo do Edit de SystemProperty
        /// </summary>
        public static string SystemPropertyEditTitle
        {
            get
            {
                return Localize("Edição de SystemProperty");
            }
        }

        /// <summary>
        /// Label do botão Create de SystemProperty
        /// </summary>
        public static string SystemPropertyCreateButton
        {
            get
            {
                return Localize("Novo SystemProperty");
            }
        }

        /// <summary>
        /// Label do botão Delete de SystemProperty
        /// </summary>
        public static string SystemPropertyDeleteButton
        {
            get
            {
                return Localize("Excluir SystemProperty");
            }
        }

        /// <summary>
        /// Titulo do index de Tag
        /// </summary>
        public static string TagIndexTitle
        {
            get
            {
                return Localize("Tag");
            }
        }

        /// <summary>
        /// Titulo do Create de Tag
        /// </summary>
        public static string TagCreateTitle
        {
            get
            {
                return Localize("Cadastro de Tag");
            }
        }

        /// <summary>
        /// Titulo do Edit de Tag
        /// </summary>
        public static string TagEditTitle
        {
            get
            {
                return Localize("Edição de Tag");
            }
        }

        /// <summary>
        /// Label do botão Create de Tag
        /// </summary>
        public static string TagCreateButton
        {
            get
            {
                return Localize("Novo Tag");
            }
        }

        /// <summary>
        /// Label do botão Delete de Tag
        /// </summary>
        public static string TagDeleteButton
        {
            get
            {
                return Localize("Excluir Tag");
            }
        }

        /// <summary>
        /// Titulo do index de Agente Inteligente
        /// </summary>
        public static string TaskDispatcherIndexTitle
        {
            get
            {
                return Localize("Agente Inteligente");
            }
        }

        /// <summary>
        /// Titulo do Create de Agente Inteligente
        /// </summary>
        public static string TaskDispatcherCreateTitle
        {
            get
            {
                return Localize("Cadastro de Agente Inteligente");
            }
        }

        /// <summary>
        /// Titulo do Edit de Agente Inteligente
        /// </summary>
        public static string TaskDispatcherEditTitle
        {
            get
            {
                return Localize("Edição de Agente Inteligente");
            }
        }

        /// <summary>
        /// Label do botão Create de Agente Inteligente
        /// </summary>
        public static string TaskDispatcherCreateButton
        {
            get
            {
                return Localize("Novo Agente Inteligente");
            }
        }

        /// <summary>
        /// Label do botão Delete de Agente Inteligente
        /// </summary>
        public static string TaskDispatcherDeleteButton
        {
            get
            {
                return Localize("Excluir Agente Inteligente");
            }
        }

        /// <summary>
        /// Titulo do index de TaskDispatcherLog
        /// </summary>
        public static string TaskDispatcherLogIndexTitle
        {
            get
            {
                return Localize("TaskDispatcherLog");
            }
        }

        /// <summary>
        /// Titulo do Create de TaskDispatcherLog
        /// </summary>
        public static string TaskDispatcherLogCreateTitle
        {
            get
            {
                return Localize("Cadastro de TaskDispatcherLog");
            }
        }

        /// <summary>
        /// Titulo do Edit de TaskDispatcherLog
        /// </summary>
        public static string TaskDispatcherLogEditTitle
        {
            get
            {
                return Localize("Edição de TaskDispatcherLog");
            }
        }

        /// <summary>
        /// Label do botão Create de TaskDispatcherLog
        /// </summary>
        public static string TaskDispatcherLogCreateButton
        {
            get
            {
                return Localize("Novo TaskDispatcherLog");
            }
        }

        /// <summary>
        /// Label do botão Delete de TaskDispatcherLog
        /// </summary>
        public static string TaskDispatcherLogDeleteButton
        {
            get
            {
                return Localize("Excluir TaskDispatcherLog");
            }
        }

        /// <summary>
        /// Titulo do index de Palavras-Chave
        /// </summary>
        public static string TextMatchKeyWordsQuestionIndexTitle
        {
            get
            {
                return Localize("Palavras-Chave");
            }
        }

        /// <summary>
        /// Titulo do Create de Palavras-Chave
        /// </summary>
        public static string TextMatchKeyWordsQuestionCreateTitle
        {
            get
            {
                return Localize("Cadastro de Palavras-Chave");
            }
        }

        /// <summary>
        /// Titulo do Edit de Palavras-Chave
        /// </summary>
        public static string TextMatchKeyWordsQuestionEditTitle
        {
            get
            {
                return Localize("Edição de Palavras-Chave");
            }
        }

        /// <summary>
        /// Label do botão Create de Palavras-Chave
        /// </summary>
        public static string TextMatchKeyWordsQuestionCreateButton
        {
            get
            {
                return Localize("Novo Palavras-Chave");
            }
        }

        /// <summary>
        /// Label do botão Delete de Palavras-Chave
        /// </summary>
        public static string TextMatchKeyWordsQuestionDeleteButton
        {
            get
            {
                return Localize("Excluir Palavras-Chave");
            }
        }

        /// <summary>
        /// Titulo do index de Grupo de Sinônimos
        /// </summary>
        public static string TextMatchKeyWordsSynonymsIndexTitle
        {
            get
            {
                return Localize("Grupo de Sinônimos");
            }
        }

        /// <summary>
        /// Titulo do Create de Grupo de Sinônimos
        /// </summary>
        public static string TextMatchKeyWordsSynonymsCreateTitle
        {
            get
            {
                return Localize("Cadastro de Grupo de Sinônimos");
            }
        }

        /// <summary>
        /// Titulo do Edit de Grupo de Sinônimos
        /// </summary>
        public static string TextMatchKeyWordsSynonymsEditTitle
        {
            get
            {
                return Localize("Edição de Grupo de Sinônimos");
            }
        }

        /// <summary>
        /// Label do botão Create de Grupo de Sinônimos
        /// </summary>
        public static string TextMatchKeyWordsSynonymsCreateButton
        {
            get
            {
                return Localize("Novo Grupo de Sinônimos");
            }
        }

        /// <summary>
        /// Label do botão Delete de Grupo de Sinônimos
        /// </summary>
        public static string TextMatchKeyWordsSynonymsDeleteButton
        {
            get
            {
                return Localize("Excluir Grupo de Sinônimos");
            }
        }

        /// <summary>
        /// Titulo do index de Completar Frase
        /// </summary>
        public static string TextMatchQuestionIndexTitle
        {
            get
            {
                return Localize("Completar Frase");
            }
        }

        /// <summary>
        /// Titulo do Create de Completar Frase
        /// </summary>
        public static string TextMatchQuestionCreateTitle
        {
            get
            {
                return Localize("Cadastro de Completar Frase");
            }
        }

        /// <summary>
        /// Titulo do Edit de Completar Frase
        /// </summary>
        public static string TextMatchQuestionEditTitle
        {
            get
            {
                return Localize("Edição de Completar Frase");
            }
        }

        /// <summary>
        /// Label do botão Create de Completar Frase
        /// </summary>
        public static string TextMatchQuestionCreateButton
        {
            get
            {
                return Localize("Novo Completar Frase");
            }
        }

        /// <summary>
        /// Label do botão Delete de Completar Frase
        /// </summary>
        public static string TextMatchQuestionDeleteButton
        {
            get
            {
                return Localize("Excluir Completar Frase");
            }
        }

        /// <summary>
        /// Titulo do index de TentativaCompletarFrase
        /// </summary>
        public static string TextMatchQuestionAttemptsIndexTitle
        {
            get
            {
                return Localize("TentativaCompletarFrase");
            }
        }

        /// <summary>
        /// Titulo do Create de TentativaCompletarFrase
        /// </summary>
        public static string TextMatchQuestionAttemptsCreateTitle
        {
            get
            {
                return Localize("Cadastro de TentativaCompletarFrase");
            }
        }

        /// <summary>
        /// Titulo do Edit de TentativaCompletarFrase
        /// </summary>
        public static string TextMatchQuestionAttemptsEditTitle
        {
            get
            {
                return Localize("Edição de TentativaCompletarFrase");
            }
        }

        /// <summary>
        /// Label do botão Create de TentativaCompletarFrase
        /// </summary>
        public static string TextMatchQuestionAttemptsCreateButton
        {
            get
            {
                return Localize("Novo TentativaCompletarFrase");
            }
        }

        /// <summary>
        /// Label do botão Delete de TentativaCompletarFrase
        /// </summary>
        public static string TextMatchQuestionAttemptsDeleteButton
        {
            get
            {
                return Localize("Excluir TentativaCompletarFrase");
            }
        }

        /// <summary>
        /// Titulo do index de Theme
        /// </summary>
        public static string ThemeIndexTitle
        {
            get
            {
                return Localize("Theme");
            }
        }

        /// <summary>
        /// Titulo do Create de Theme
        /// </summary>
        public static string ThemeCreateTitle
        {
            get
            {
                return Localize("Cadastro de Theme");
            }
        }

        /// <summary>
        /// Titulo do Edit de Theme
        /// </summary>
        public static string ThemeEditTitle
        {
            get
            {
                return Localize("Edição de Theme");
            }
        }

        /// <summary>
        /// Label do botão Create de Theme
        /// </summary>
        public static string ThemeCreateButton
        {
            get
            {
                return Localize("Novo Theme");
            }
        }

        /// <summary>
        /// Label do botão Delete de Theme
        /// </summary>
        public static string ThemeDeleteButton
        {
            get
            {
                return Localize("Excluir Theme");
            }
        }

        /// <summary>
        /// Titulo do index de Treinamento
        /// </summary>
        public static string TrainingIndexTitle
        {
            get
            {
                return Localize("Treinamento");
            }
        }

        /// <summary>
        /// Titulo do Create de Treinamento
        /// </summary>
        public static string TrainingCreateTitle
        {
            get
            {
                return Localize("Cadastro de Treinamento");
            }
        }

        /// <summary>
        /// Titulo do Edit de Treinamento
        /// </summary>
        public static string TrainingEditTitle
        {
            get
            {
                return Localize("Edição de Treinamento");
            }
        }

        /// <summary>
        /// Label do botão Create de Treinamento
        /// </summary>
        public static string TrainingCreateButton
        {
            get
            {
                return Localize("Novo Treinamento");
            }
        }

        /// <summary>
        /// Label do botão Delete de Treinamento
        /// </summary>
        public static string TrainingDeleteButton
        {
            get
            {
                return Localize("Excluir Treinamento");
            }
        }

        /// <summary>
        /// Titulo do index de TrainingDeadline
        /// </summary>
        public static string TrainingDeadlineIndexTitle
        {
            get
            {
                return Localize("TrainingDeadline");
            }
        }

        /// <summary>
        /// Titulo do Create de TrainingDeadline
        /// </summary>
        public static string TrainingDeadlineCreateTitle
        {
            get
            {
                return Localize("Cadastro de TrainingDeadline");
            }
        }

        /// <summary>
        /// Titulo do Edit de TrainingDeadline
        /// </summary>
        public static string TrainingDeadlineEditTitle
        {
            get
            {
                return Localize("Edição de TrainingDeadline");
            }
        }

        /// <summary>
        /// Label do botão Create de TrainingDeadline
        /// </summary>
        public static string TrainingDeadlineCreateButton
        {
            get
            {
                return Localize("Novo TrainingDeadline");
            }
        }

        /// <summary>
        /// Label do botão Delete de TrainingDeadline
        /// </summary>
        public static string TrainingDeadlineDeleteButton
        {
            get
            {
                return Localize("Excluir TrainingDeadline");
            }
        }

        /// <summary>
        /// Titulo do index de Realização Treinamento
        /// </summary>
        public static string TrainingRealizationIndexTitle
        {
            get
            {
                return Localize("Realização Treinamento");
            }
        }

        /// <summary>
        /// Titulo do Create de Realização Treinamento
        /// </summary>
        public static string TrainingRealizationCreateTitle
        {
            get
            {
                return Localize("Cadastro de Realização Treinamento");
            }
        }

        /// <summary>
        /// Titulo do Edit de Realização Treinamento
        /// </summary>
        public static string TrainingRealizationEditTitle
        {
            get
            {
                return Localize("Edição de Realização Treinamento");
            }
        }

        /// <summary>
        /// Label do botão Create de Realização Treinamento
        /// </summary>
        public static string TrainingRealizationCreateButton
        {
            get
            {
                return Localize("Novo Realização Treinamento");
            }
        }

        /// <summary>
        /// Label do botão Delete de Realização Treinamento
        /// </summary>
        public static string TrainingRealizationDeleteButton
        {
            get
            {
                return Localize("Excluir Realização Treinamento");
            }
        }

        /// <summary>
        /// Titulo do index de Histórico Realização Consolidado
        /// </summary>
        public static string TrainingRealizationSolidDataIndexTitle
        {
            get
            {
                return Localize("Histórico Realização Consolidado");
            }
        }

        /// <summary>
        /// Titulo do Create de Histórico Realização Consolidado
        /// </summary>
        public static string TrainingRealizationSolidDataCreateTitle
        {
            get
            {
                return Localize("Cadastro de Histórico Realização Consolidado");
            }
        }

        /// <summary>
        /// Titulo do Edit de Histórico Realização Consolidado
        /// </summary>
        public static string TrainingRealizationSolidDataEditTitle
        {
            get
            {
                return Localize("Edição de Histórico Realização Consolidado");
            }
        }

        /// <summary>
        /// Label do botão Create de Histórico Realização Consolidado
        /// </summary>
        public static string TrainingRealizationSolidDataCreateButton
        {
            get
            {
                return Localize("Novo Histórico Realização Consolidado");
            }
        }

        /// <summary>
        /// Label do botão Delete de Histórico Realização Consolidado
        /// </summary>
        public static string TrainingRealizationSolidDataDeleteButton
        {
            get
            {
                return Localize("Excluir Histórico Realização Consolidado");
            }
        }

        /// <summary>
        /// Titulo do index de Tutoria
        /// </summary>
        public static string TutoringIndexTitle
        {
            get
            {
                return Localize("Tutoria");
            }
        }

        /// <summary>
        /// Titulo do Create de Tutoria
        /// </summary>
        public static string TutoringCreateTitle
        {
            get
            {
                return Localize("Cadastro de Tutoria");
            }
        }

        /// <summary>
        /// Titulo do Edit de Tutoria
        /// </summary>
        public static string TutoringEditTitle
        {
            get
            {
                return Localize("Edição de Tutoria");
            }
        }

        /// <summary>
        /// Label do botão Create de Tutoria
        /// </summary>
        public static string TutoringCreateButton
        {
            get
            {
                return Localize("Novo Tutoria");
            }
        }

        /// <summary>
        /// Label do botão Delete de Tutoria
        /// </summary>
        public static string TutoringDeleteButton
        {
            get
            {
                return Localize("Excluir Tutoria");
            }
        }

        /// <summary>
        /// Titulo do index de TypeLog
        /// </summary>
        public static string TypeLogIndexTitle
        {
            get
            {
                return Localize("TypeLog");
            }
        }

        /// <summary>
        /// Titulo do Create de TypeLog
        /// </summary>
        public static string TypeLogCreateTitle
        {
            get
            {
                return Localize("Cadastro de TypeLog");
            }
        }

        /// <summary>
        /// Titulo do Edit de TypeLog
        /// </summary>
        public static string TypeLogEditTitle
        {
            get
            {
                return Localize("Edição de TypeLog");
            }
        }

        /// <summary>
        /// Label do botão Create de TypeLog
        /// </summary>
        public static string TypeLogCreateButton
        {
            get
            {
                return Localize("Novo TypeLog");
            }
        }

        /// <summary>
        /// Label do botão Delete de TypeLog
        /// </summary>
        public static string TypeLogDeleteButton
        {
            get
            {
                return Localize("Excluir TypeLog");
            }
        }

        /// <summary>
        /// Titulo do index de Unit
        /// </summary>
        public static string UnitIndexTitle
        {
            get
            {
                return Localize("Unit");
            }
        }

        /// <summary>
        /// Titulo do Create de Unit
        /// </summary>
        public static string UnitCreateTitle
        {
            get
            {
                return Localize("Cadastro de Unit");
            }
        }

        /// <summary>
        /// Titulo do Edit de Unit
        /// </summary>
        public static string UnitEditTitle
        {
            get
            {
                return Localize("Edição de Unit");
            }
        }

        /// <summary>
        /// Label do botão Create de Unit
        /// </summary>
        public static string UnitCreateButton
        {
            get
            {
                return Localize("Novo Unit");
            }
        }

        /// <summary>
        /// Label do botão Delete de Unit
        /// </summary>
        public static string UnitDeleteButton
        {
            get
            {
                return Localize("Excluir Unit");
            }
        }

        /// <summary>
        /// Titulo do index de UnitUser
        /// </summary>
        public static string UnitUserIndexTitle
        {
            get
            {
                return Localize("UnitUser");
            }
        }

        /// <summary>
        /// Titulo do Create de UnitUser
        /// </summary>
        public static string UnitUserCreateTitle
        {
            get
            {
                return Localize("Cadastro de UnitUser");
            }
        }

        /// <summary>
        /// Titulo do Edit de UnitUser
        /// </summary>
        public static string UnitUserEditTitle
        {
            get
            {
                return Localize("Edição de UnitUser");
            }
        }

        /// <summary>
        /// Label do botão Create de UnitUser
        /// </summary>
        public static string UnitUserCreateButton
        {
            get
            {
                return Localize("Novo UnitUser");
            }
        }

        /// <summary>
        /// Label do botão Delete de UnitUser
        /// </summary>
        public static string UnitUserDeleteButton
        {
            get
            {
                return Localize("Excluir UnitUser");
            }
        }

        /// <summary>
        /// Titulo do index de User
        /// </summary>
        public static string UserIndexTitle
        {
            get
            {
                return Localize("User");
            }
        }

        /// <summary>
        /// Titulo do Create de User
        /// </summary>
        public static string UserCreateTitle
        {
            get
            {
                return Localize("Cadastro de User");
            }
        }

        /// <summary>
        /// Titulo do Edit de User
        /// </summary>
        public static string UserEditTitle
        {
            get
            {
                return Localize("Edição de User");
            }
        }

        /// <summary>
        /// Label do botão Create de User
        /// </summary>
        public static string UserCreateButton
        {
            get
            {
                return Localize("Novo User");
            }
        }

        /// <summary>
        /// Label do botão Delete de User
        /// </summary>
        public static string UserDeleteButton
        {
            get
            {
                return Localize("Excluir User");
            }
        }

        /// <summary>
        /// Titulo do index de UserCustomization
        /// </summary>
        public static string UserCustomizationIndexTitle
        {
            get
            {
                return Localize("UserCustomization");
            }
        }

        /// <summary>
        /// Titulo do Create de UserCustomization
        /// </summary>
        public static string UserCustomizationCreateTitle
        {
            get
            {
                return Localize("Cadastro de UserCustomization");
            }
        }

        /// <summary>
        /// Titulo do Edit de UserCustomization
        /// </summary>
        public static string UserCustomizationEditTitle
        {
            get
            {
                return Localize("Edição de UserCustomization");
            }
        }

        /// <summary>
        /// Label do botão Create de UserCustomization
        /// </summary>
        public static string UserCustomizationCreateButton
        {
            get
            {
                return Localize("Novo UserCustomization");
            }
        }

        /// <summary>
        /// Label do botão Delete de UserCustomization
        /// </summary>
        public static string UserCustomizationDeleteButton
        {
            get
            {
                return Localize("Excluir UserCustomization");
            }
        }

        /// <summary>
        /// Titulo do index de Realização Feedback
        /// </summary>
        public static string UserFeedbackIndexTitle
        {
            get
            {
                return Localize("Realização Feedback");
            }
        }

        /// <summary>
        /// Titulo do Create de Realização Feedback
        /// </summary>
        public static string UserFeedbackCreateTitle
        {
            get
            {
                return Localize("Cadastro de Realização Feedback");
            }
        }

        /// <summary>
        /// Titulo do Edit de Realização Feedback
        /// </summary>
        public static string UserFeedbackEditTitle
        {
            get
            {
                return Localize("Edição de Realização Feedback");
            }
        }

        /// <summary>
        /// Label do botão Create de Realização Feedback
        /// </summary>
        public static string UserFeedbackCreateButton
        {
            get
            {
                return Localize("Novo Realização Feedback");
            }
        }

        /// <summary>
        /// Label do botão Delete de Realização Feedback
        /// </summary>
        public static string UserFeedbackDeleteButton
        {
            get
            {
                return Localize("Excluir Realização Feedback");
            }
        }

        /// <summary>
        /// Titulo do index de UserMessage
        /// </summary>
        public static string UserMessageIndexTitle
        {
            get
            {
                return Localize("UserMessage");
            }
        }

        /// <summary>
        /// Titulo do Create de UserMessage
        /// </summary>
        public static string UserMessageCreateTitle
        {
            get
            {
                return Localize("Cadastro de UserMessage");
            }
        }

        /// <summary>
        /// Titulo do Edit de UserMessage
        /// </summary>
        public static string UserMessageEditTitle
        {
            get
            {
                return Localize("Edição de UserMessage");
            }
        }

        /// <summary>
        /// Label do botão Create de UserMessage
        /// </summary>
        public static string UserMessageCreateButton
        {
            get
            {
                return Localize("Novo UserMessage");
            }
        }

        /// <summary>
        /// Label do botão Delete de UserMessage
        /// </summary>
        public static string UserMessageDeleteButton
        {
            get
            {
                return Localize("Excluir UserMessage");
            }
        }

        /// <summary>
        /// Titulo do index de UsersPermissions
        /// </summary>
        public static string UsersPermissionsIndexTitle
        {
            get
            {
                return Localize("UsersPermissions");
            }
        }

        /// <summary>
        /// Titulo do Create de UsersPermissions
        /// </summary>
        public static string UsersPermissionsCreateTitle
        {
            get
            {
                return Localize("Cadastro de UsersPermissions");
            }
        }

        /// <summary>
        /// Titulo do Edit de UsersPermissions
        /// </summary>
        public static string UsersPermissionsEditTitle
        {
            get
            {
                return Localize("Edição de UsersPermissions");
            }
        }

        /// <summary>
        /// Label do botão Create de UsersPermissions
        /// </summary>
        public static string UsersPermissionsCreateButton
        {
            get
            {
                return Localize("Novo UsersPermissions");
            }
        }

        /// <summary>
        /// Label do botão Delete de UsersPermissions
        /// </summary>
        public static string UsersPermissionsDeleteButton
        {
            get
            {
                return Localize("Excluir UsersPermissions");
            }
        }

        /// <summary>
        /// Titulo do index de UserTypeMessage
        /// </summary>
        public static string UserTypeMessageIndexTitle
        {
            get
            {
                return Localize("UserTypeMessage");
            }
        }

        /// <summary>
        /// Titulo do Create de UserTypeMessage
        /// </summary>
        public static string UserTypeMessageCreateTitle
        {
            get
            {
                return Localize("Cadastro de UserTypeMessage");
            }
        }

        /// <summary>
        /// Titulo do Edit de UserTypeMessage
        /// </summary>
        public static string UserTypeMessageEditTitle
        {
            get
            {
                return Localize("Edição de UserTypeMessage");
            }
        }

        /// <summary>
        /// Label do botão Create de UserTypeMessage
        /// </summary>
        public static string UserTypeMessageCreateButton
        {
            get
            {
                return Localize("Novo UserTypeMessage");
            }
        }

        /// <summary>
        /// Label do botão Delete de UserTypeMessage
        /// </summary>
        public static string UserTypeMessageDeleteButton
        {
            get
            {
                return Localize("Excluir UserTypeMessage");
            }
        }

        /// <summary>
        /// Titulo do index de Aceites Termo de Uso
        /// </summary>
        public static string UserUseTermsIndexTitle
        {
            get
            {
                return Localize("Aceites Termo de Uso");
            }
        }

        /// <summary>
        /// Titulo do Create de Aceites Termo de Uso
        /// </summary>
        public static string UserUseTermsCreateTitle
        {
            get
            {
                return Localize("Cadastro de Aceites Termo de Uso");
            }
        }

        /// <summary>
        /// Titulo do Edit de Aceites Termo de Uso
        /// </summary>
        public static string UserUseTermsEditTitle
        {
            get
            {
                return Localize("Edição de Aceites Termo de Uso");
            }
        }

        /// <summary>
        /// Label do botão Create de Aceites Termo de Uso
        /// </summary>
        public static string UserUseTermsCreateButton
        {
            get
            {
                return Localize("Novo Aceites Termo de Uso");
            }
        }

        /// <summary>
        /// Label do botão Delete de Aceites Termo de Uso
        /// </summary>
        public static string UserUseTermsDeleteButton
        {
            get
            {
                return Localize("Excluir Aceites Termo de Uso");
            }
        }

        /// <summary>
        /// Titulo do index de Trabalho Usuários
        /// </summary>
        public static string UserWorkpaperIndexTitle
        {
            get
            {
                return Localize("Trabalho Usuários");
            }
        }

        /// <summary>
        /// Titulo do Create de Trabalho Usuários
        /// </summary>
        public static string UserWorkpaperCreateTitle
        {
            get
            {
                return Localize("Cadastro de Trabalho Usuários");
            }
        }

        /// <summary>
        /// Titulo do Edit de Trabalho Usuários
        /// </summary>
        public static string UserWorkpaperEditTitle
        {
            get
            {
                return Localize("Edição de Trabalho Usuários");
            }
        }

        /// <summary>
        /// Label do botão Create de Trabalho Usuários
        /// </summary>
        public static string UserWorkpaperCreateButton
        {
            get
            {
                return Localize("Novo Trabalho Usuários");
            }
        }

        /// <summary>
        /// Label do botão Delete de Trabalho Usuários
        /// </summary>
        public static string UserWorkpaperDeleteButton
        {
            get
            {
                return Localize("Excluir Trabalho Usuários");
            }
        }

        /// <summary>
        /// Titulo do index de Termo de Uso
        /// </summary>
        public static string UseTermsIndexTitle
        {
            get
            {
                return Localize("Termo de Uso");
            }
        }

        /// <summary>
        /// Titulo do Create de Termo de Uso
        /// </summary>
        public static string UseTermsCreateTitle
        {
            get
            {
                return Localize("Cadastro de Termo de Uso");
            }
        }

        /// <summary>
        /// Titulo do Edit de Termo de Uso
        /// </summary>
        public static string UseTermsEditTitle
        {
            get
            {
                return Localize("Edição de Termo de Uso");
            }
        }

        /// <summary>
        /// Label do botão Create de Termo de Uso
        /// </summary>
        public static string UseTermsCreateButton
        {
            get
            {
                return Localize("Novo Termo de Uso");
            }
        }

        /// <summary>
        /// Label do botão Delete de Termo de Uso
        /// </summary>
        public static string UseTermsDeleteButton
        {
            get
            {
                return Localize("Excluir Termo de Uso");
            }
        }

        /// <summary>
        /// Titulo do index de Widget
        /// </summary>
        public static string WidgetIndexTitle
        {
            get
            {
                return Localize("Widget");
            }
        }

        /// <summary>
        /// Titulo do Create de Widget
        /// </summary>
        public static string WidgetCreateTitle
        {
            get
            {
                return Localize("Cadastro de Widget");
            }
        }

        /// <summary>
        /// Titulo do Edit de Widget
        /// </summary>
        public static string WidgetEditTitle
        {
            get
            {
                return Localize("Edição de Widget");
            }
        }

        /// <summary>
        /// Label do botão Create de Widget
        /// </summary>
        public static string WidgetCreateButton
        {
            get
            {
                return Localize("Novo Widget");
            }
        }

        /// <summary>
        /// Label do botão Delete de Widget
        /// </summary>
        public static string WidgetDeleteButton
        {
            get
            {
                return Localize("Excluir Widget");
            }
        }

        /// <summary>
        /// Titulo do index de Wiki
        /// </summary>
        public static string WikiIndexTitle
        {
            get
            {
                return Localize("Wiki");
            }
        }

        /// <summary>
        /// Titulo do Create de Wiki
        /// </summary>
        public static string WikiCreateTitle
        {
            get
            {
                return Localize("Cadastro de Wiki");
            }
        }

        /// <summary>
        /// Titulo do Edit de Wiki
        /// </summary>
        public static string WikiEditTitle
        {
            get
            {
                return Localize("Edição de Wiki");
            }
        }

        /// <summary>
        /// Label do botão Create de Wiki
        /// </summary>
        public static string WikiCreateButton
        {
            get
            {
                return Localize("Novo Wiki");
            }
        }

        /// <summary>
        /// Label do botão Delete de Wiki
        /// </summary>
        public static string WikiDeleteButton
        {
            get
            {
                return Localize("Excluir Wiki");
            }
        }

        /// <summary>
        /// Titulo do index de WikiClass
        /// </summary>
        public static string WikiClassIndexTitle
        {
            get
            {
                return Localize("WikiClass");
            }
        }

        /// <summary>
        /// Titulo do Create de WikiClass
        /// </summary>
        public static string WikiClassCreateTitle
        {
            get
            {
                return Localize("Cadastro de WikiClass");
            }
        }

        /// <summary>
        /// Titulo do Edit de WikiClass
        /// </summary>
        public static string WikiClassEditTitle
        {
            get
            {
                return Localize("Edição de WikiClass");
            }
        }

        /// <summary>
        /// Label do botão Create de WikiClass
        /// </summary>
        public static string WikiClassCreateButton
        {
            get
            {
                return Localize("Novo WikiClass");
            }
        }

        /// <summary>
        /// Label do botão Delete de WikiClass
        /// </summary>
        public static string WikiClassDeleteButton
        {
            get
            {
                return Localize("Excluir WikiClass");
            }
        }

        /// <summary>
        /// Titulo do index de WikiCourse
        /// </summary>
        public static string WikiCourseIndexTitle
        {
            get
            {
                return Localize("WikiCourse");
            }
        }

        /// <summary>
        /// Titulo do Create de WikiCourse
        /// </summary>
        public static string WikiCourseCreateTitle
        {
            get
            {
                return Localize("Cadastro de WikiCourse");
            }
        }

        /// <summary>
        /// Titulo do Edit de WikiCourse
        /// </summary>
        public static string WikiCourseEditTitle
        {
            get
            {
                return Localize("Edição de WikiCourse");
            }
        }

        /// <summary>
        /// Label do botão Create de WikiCourse
        /// </summary>
        public static string WikiCourseCreateButton
        {
            get
            {
                return Localize("Novo WikiCourse");
            }
        }

        /// <summary>
        /// Label do botão Delete de WikiCourse
        /// </summary>
        public static string WikiCourseDeleteButton
        {
            get
            {
                return Localize("Excluir WikiCourse");
            }
        }

        /// <summary>
        /// Titulo do index de WikiProfile
        /// </summary>
        public static string WikiProfileIndexTitle
        {
            get
            {
                return Localize("WikiProfile");
            }
        }

        /// <summary>
        /// Titulo do Create de WikiProfile
        /// </summary>
        public static string WikiProfileCreateTitle
        {
            get
            {
                return Localize("Cadastro de WikiProfile");
            }
        }

        /// <summary>
        /// Titulo do Edit de WikiProfile
        /// </summary>
        public static string WikiProfileEditTitle
        {
            get
            {
                return Localize("Edição de WikiProfile");
            }
        }

        /// <summary>
        /// Label do botão Create de WikiProfile
        /// </summary>
        public static string WikiProfileCreateButton
        {
            get
            {
                return Localize("Novo WikiProfile");
            }
        }

        /// <summary>
        /// Label do botão Delete de WikiProfile
        /// </summary>
        public static string WikiProfileDeleteButton
        {
            get
            {
                return Localize("Excluir WikiProfile");
            }
        }

        /// <summary>
        /// Titulo do index de WikiProgram
        /// </summary>
        public static string WikiProgramIndexTitle
        {
            get
            {
                return Localize("WikiProgram");
            }
        }

        /// <summary>
        /// Titulo do Create de WikiProgram
        /// </summary>
        public static string WikiProgramCreateTitle
        {
            get
            {
                return Localize("Cadastro de WikiProgram");
            }
        }

        /// <summary>
        /// Titulo do Edit de WikiProgram
        /// </summary>
        public static string WikiProgramEditTitle
        {
            get
            {
                return Localize("Edição de WikiProgram");
            }
        }

        /// <summary>
        /// Label do botão Create de WikiProgram
        /// </summary>
        public static string WikiProgramCreateButton
        {
            get
            {
                return Localize("Novo WikiProgram");
            }
        }

        /// <summary>
        /// Label do botão Delete de WikiProgram
        /// </summary>
        public static string WikiProgramDeleteButton
        {
            get
            {
                return Localize("Excluir WikiProgram");
            }
        }

        /// <summary>
        /// Titulo do index de WikiUnit
        /// </summary>
        public static string WikiUnitIndexTitle
        {
            get
            {
                return Localize("WikiUnit");
            }
        }

        /// <summary>
        /// Titulo do Create de WikiUnit
        /// </summary>
        public static string WikiUnitCreateTitle
        {
            get
            {
                return Localize("Cadastro de WikiUnit");
            }
        }

        /// <summary>
        /// Titulo do Edit de WikiUnit
        /// </summary>
        public static string WikiUnitEditTitle
        {
            get
            {
                return Localize("Edição de WikiUnit");
            }
        }

        /// <summary>
        /// Label do botão Create de WikiUnit
        /// </summary>
        public static string WikiUnitCreateButton
        {
            get
            {
                return Localize("Novo WikiUnit");
            }
        }

        /// <summary>
        /// Label do botão Delete de WikiUnit
        /// </summary>
        public static string WikiUnitDeleteButton
        {
            get
            {
                return Localize("Excluir WikiUnit");
            }
        }

        /// <summary>
        /// Titulo do index de WikiAccess
        /// </summary>
        public static string WikiAccessIndexTitle
        {
            get
            {
                return Localize("WikiAccess");
            }
        }

        /// <summary>
        /// Titulo do Create de WikiAccess
        /// </summary>
        public static string WikiAccessCreateTitle
        {
            get
            {
                return Localize("Cadastro de WikiAccess");
            }
        }

        /// <summary>
        /// Titulo do Edit de WikiAccess
        /// </summary>
        public static string WikiAccessEditTitle
        {
            get
            {
                return Localize("Edição de WikiAccess");
            }
        }

        /// <summary>
        /// Label do botão Create de WikiAccess
        /// </summary>
        public static string WikiAccessCreateButton
        {
            get
            {
                return Localize("Novo WikiAccess");
            }
        }

        /// <summary>
        /// Label do botão Delete de WikiAccess
        /// </summary>
        public static string WikiAccessDeleteButton
        {
            get
            {
                return Localize("Excluir WikiAccess");
            }
        }

        /// <summary>
        /// Titulo do index de WikiCategory
        /// </summary>
        public static string WikiCategoryIndexTitle
        {
            get
            {
                return Localize("WikiCategory");
            }
        }

        /// <summary>
        /// Titulo do Create de WikiCategory
        /// </summary>
        public static string WikiCategoryCreateTitle
        {
            get
            {
                return Localize("Cadastro de WikiCategory");
            }
        }

        /// <summary>
        /// Titulo do Edit de WikiCategory
        /// </summary>
        public static string WikiCategoryEditTitle
        {
            get
            {
                return Localize("Edição de WikiCategory");
            }
        }

        /// <summary>
        /// Label do botão Create de WikiCategory
        /// </summary>
        public static string WikiCategoryCreateButton
        {
            get
            {
                return Localize("Novo WikiCategory");
            }
        }

        /// <summary>
        /// Label do botão Delete de WikiCategory
        /// </summary>
        public static string WikiCategoryDeleteButton
        {
            get
            {
                return Localize("Excluir WikiCategory");
            }
        }

        /// <summary>
        /// Titulo do index de WikiComment
        /// </summary>
        public static string WikiCommentIndexTitle
        {
            get
            {
                return Localize("WikiComment");
            }
        }

        /// <summary>
        /// Titulo do Create de WikiComment
        /// </summary>
        public static string WikiCommentCreateTitle
        {
            get
            {
                return Localize("Cadastro de WikiComment");
            }
        }

        /// <summary>
        /// Titulo do Edit de WikiComment
        /// </summary>
        public static string WikiCommentEditTitle
        {
            get
            {
                return Localize("Edição de WikiComment");
            }
        }

        /// <summary>
        /// Label do botão Create de WikiComment
        /// </summary>
        public static string WikiCommentCreateButton
        {
            get
            {
                return Localize("Novo WikiComment");
            }
        }

        /// <summary>
        /// Label do botão Delete de WikiComment
        /// </summary>
        public static string WikiCommentDeleteButton
        {
            get
            {
                return Localize("Excluir WikiComment");
            }
        }

        /// <summary>
        /// Titulo do index de WikiContent
        /// </summary>
        public static string WikiContentIndexTitle
        {
            get
            {
                return Localize("WikiContent");
            }
        }

        /// <summary>
        /// Titulo do Create de WikiContent
        /// </summary>
        public static string WikiContentCreateTitle
        {
            get
            {
                return Localize("Cadastro de WikiContent");
            }
        }

        /// <summary>
        /// Titulo do Edit de WikiContent
        /// </summary>
        public static string WikiContentEditTitle
        {
            get
            {
                return Localize("Edição de WikiContent");
            }
        }

        /// <summary>
        /// Label do botão Create de WikiContent
        /// </summary>
        public static string WikiContentCreateButton
        {
            get
            {
                return Localize("Novo WikiContent");
            }
        }

        /// <summary>
        /// Label do botão Delete de WikiContent
        /// </summary>
        public static string WikiContentDeleteButton
        {
            get
            {
                return Localize("Excluir WikiContent");
            }
        }

        /// <summary>
        /// Titulo do index de WikiContentTag
        /// </summary>
        public static string WikiContentTagIndexTitle
        {
            get
            {
                return Localize("WikiContentTag");
            }
        }

        /// <summary>
        /// Titulo do Create de WikiContentTag
        /// </summary>
        public static string WikiContentTagCreateTitle
        {
            get
            {
                return Localize("Cadastro de WikiContentTag");
            }
        }

        /// <summary>
        /// Titulo do Edit de WikiContentTag
        /// </summary>
        public static string WikiContentTagEditTitle
        {
            get
            {
                return Localize("Edição de WikiContentTag");
            }
        }

        /// <summary>
        /// Label do botão Create de WikiContentTag
        /// </summary>
        public static string WikiContentTagCreateButton
        {
            get
            {
                return Localize("Novo WikiContentTag");
            }
        }

        /// <summary>
        /// Label do botão Delete de WikiContentTag
        /// </summary>
        public static string WikiContentTagDeleteButton
        {
            get
            {
                return Localize("Excluir WikiContentTag");
            }
        }

        /// <summary>
        /// Titulo do index de WikiVersion
        /// </summary>
        public static string WikiVersionIndexTitle
        {
            get
            {
                return Localize("WikiVersion");
            }
        }

        /// <summary>
        /// Titulo do Create de WikiVersion
        /// </summary>
        public static string WikiVersionCreateTitle
        {
            get
            {
                return Localize("Cadastro de WikiVersion");
            }
        }

        /// <summary>
        /// Titulo do Edit de WikiVersion
        /// </summary>
        public static string WikiVersionEditTitle
        {
            get
            {
                return Localize("Edição de WikiVersion");
            }
        }

        /// <summary>
        /// Label do botão Create de WikiVersion
        /// </summary>
        public static string WikiVersionCreateButton
        {
            get
            {
                return Localize("Novo WikiVersion");
            }
        }

        /// <summary>
        /// Label do botão Delete de WikiVersion
        /// </summary>
        public static string WikiVersionDeleteButton
        {
            get
            {
                return Localize("Excluir WikiVersion");
            }
        }

        /// <summary>
        /// Titulo do index de Trabalho
        /// </summary>
        public static string WorkpaperIndexTitle
        {
            get
            {
                return Localize("Trabalho");
            }
        }

        /// <summary>
        /// Titulo do Create de Trabalho
        /// </summary>
        public static string WorkpaperCreateTitle
        {
            get
            {
                return Localize("Cadastro de Trabalho");
            }
        }

        /// <summary>
        /// Titulo do Edit de Trabalho
        /// </summary>
        public static string WorkpaperEditTitle
        {
            get
            {
                return Localize("Edição de Trabalho");
            }
        }

        /// <summary>
        /// Label do botão Create de Trabalho
        /// </summary>
        public static string WorkpaperCreateButton
        {
            get
            {
                return Localize("Novo Trabalho");
            }
        }

        /// <summary>
        /// Label do botão Delete de Trabalho
        /// </summary>
        public static string WorkpaperDeleteButton
        {
            get
            {
                return Localize("Excluir Trabalho");
            }
        }

        /// <summary>
        /// Titulo do index de Realização Trabalho
        /// </summary>
        public static string WorkpaperRealizationIndexTitle
        {
            get
            {
                return Localize("Realização Trabalho");
            }
        }

        /// <summary>
        /// Titulo do Create de Realização Trabalho
        /// </summary>
        public static string WorkpaperRealizationCreateTitle
        {
            get
            {
                return Localize("Cadastro de Realização Trabalho");
            }
        }

        /// <summary>
        /// Titulo do Edit de Realização Trabalho
        /// </summary>
        public static string WorkpaperRealizationEditTitle
        {
            get
            {
                return Localize("Edição de Realização Trabalho");
            }
        }

        /// <summary>
        /// Label do botão Create de Realização Trabalho
        /// </summary>
        public static string WorkpaperRealizationCreateButton
        {
            get
            {
                return Localize("Novo Realização Trabalho");
            }
        }

        /// <summary>
        /// Label do botão Delete de Realização Trabalho
        /// </summary>
        public static string WorkpaperRealizationDeleteButton
        {
            get
            {
                return Localize("Excluir Realização Trabalho");
            }
        }

        /// <summary>
        /// Titulo do index de Trabalho Rejeitado
        /// </summary>
        public static string WorkpaperRejectedIndexTitle
        {
            get
            {
                return Localize("Trabalho Rejeitado");
            }
        }

        /// <summary>
        /// Titulo do Create de Trabalho Rejeitado
        /// </summary>
        public static string WorkpaperRejectedCreateTitle
        {
            get
            {
                return Localize("Cadastro de Trabalho Rejeitado");
            }
        }

        /// <summary>
        /// Titulo do Edit de Trabalho Rejeitado
        /// </summary>
        public static string WorkpaperRejectedEditTitle
        {
            get
            {
                return Localize("Edição de Trabalho Rejeitado");
            }
        }

        /// <summary>
        /// Label do botão Create de Trabalho Rejeitado
        /// </summary>
        public static string WorkpaperRejectedCreateButton
        {
            get
            {
                return Localize("Novo Trabalho Rejeitado");
            }
        }

        /// <summary>
        /// Label do botão Delete de Trabalho Rejeitado
        /// </summary>
        public static string WorkpaperRejectedDeleteButton
        {
            get
            {
                return Localize("Excluir Trabalho Rejeitado");
            }
        }

        /// <summary>
        /// Titulo do index de Zone
        /// </summary>
        public static string ZoneIndexTitle
        {
            get
            {
                return Localize("Zone");
            }
        }

        /// <summary>
        /// Titulo do Create de Zone
        /// </summary>
        public static string ZoneCreateTitle
        {
            get
            {
                return Localize("Cadastro de Zone");
            }
        }

        /// <summary>
        /// Titulo do Edit de Zone
        /// </summary>
        public static string ZoneEditTitle
        {
            get
            {
                return Localize("Edição de Zone");
            }
        }

        /// <summary>
        /// Label do botão Create de Zone
        /// </summary>
        public static string ZoneCreateButton
        {
            get
            {
                return Localize("Novo Zone");
            }
        }

        /// <summary>
        /// Label do botão Delete de Zone
        /// </summary>
        public static string ZoneDeleteButton
        {
            get
            {
                return Localize("Excluir Zone");
            }
        }
    }
}
