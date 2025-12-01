using HxCore;
using iTextSharp.text.xml;
using Microsoft.Exchange.WebServices.Data;
using Newtonsoft.Json;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Database;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.util;

namespace TxFarmDiaryAI
{
    
    public struct TWeaterKMA_Response_Body
    {

        [Description("관측일 (KST)"                 )] public string TM                { get; set; }
        [Description("국내 지점번호"                )] public string STN               { get; set; }
        [Description("일 평균 풍속 (m/s)"           )] public string WS_AVG            { get; set; }
        [Description("일 풍정 (m)"                  )] public string WR_DAY            { get; set; }
        [Description("최대풍향"                     )] public string WD_MAX            { get; set; }
        [Description("최대풍속 (m/s)"               )] public string WS_MAX            { get; set; }
        [Description("최대풍속 시각 (시분)"         )] public string WS_MAX_TM         { get; set; }
        [Description("최대순간풍향"                 )] public string WD_INS            { get; set; }
        [Description("최대순간풍속 (m/s)"           )] public string WS_INS            { get; set; }
        [Description("최대순간풍속 시각 (시분)"     )] public string WS_INS_TM         { get; set; }
        [Description("일 평균기온 (C)"              )] public string TA_AVG            { get; set; }
        [Description("최고기온 (C)"                 )] public string TA_MAX            { get; set; }
        [Description("최고기온 시가 (시분)"         )] public string TA_MAX_TM         { get; set; }
        [Description("최저기온 (C)"                 )] public string TA_MIN            { get; set; }
        [Description("최저기온 시각 (시분)"         )] public string TA_MIN_TM         { get; set; }
        [Description("일 평균 이슬점온도 (C)"       )] public string TD_AVG            { get; set; }
        [Description("일 평균 지면온도 (C)"         )] public string TS_AVG            { get; set; }
        [Description("일 최저 초상온도 (C)"         )] public string TG_MIN            { get; set; }
        [Description("일 평균 상대습도 (%)"         )] public string HM_AVG            { get; set; }
        [Description("최저습도 (%)"                 )] public string HM_MIN            { get; set; }
        [Description("최저습도 시각 (시분)"         )] public string HM_MIN_TM         { get; set; }
        [Description("일 평균 수증기압 (hPa)"       )] public string PV_AVG            { get; set; }
        [Description("소형 증발량 (mm)"             )] public string EV_S              { get; set; }
        [Description("대형 증발량 (mm)"             )] public string EV_L              { get; set; }
        [Description("안개계속시간 (hr)"            )] public string FG_DUR            { get; set; }
        [Description("일 평균 현지기압 (hPa)"       )] public string PA_AVG            { get; set; }
        [Description("일 평균 해면기압 (hPa)"       )] public string PS_AVG            { get; set; }
        [Description("최고 해면기압 (hPa)"          )] public string PS_MAX            { get; set; }
        [Description("최고 해면기압 시각 (시분)"    )] public string PS_MAX_TM         { get; set; }
        [Description("최저 해면기압 (hPa)"          )] public string PS_MIN            { get; set; }
        [Description("최저 해면기압 시각 (시분)"    )] public string PS_MIN_TM         { get; set; }
        [Description("일 평균 전운량 (1/10)"        )] public string CA_TOT            { get; set; }
        [Description("일조합 (hr)"                  )] public string SS_DAY            { get; set; }
        [Description("가조시간 (hr)"                )] public string SS_DUR            { get; set; }
        [Description("캄벨 일조 (hr)"               )] public string SS_CMB            { get; set; }
        [Description("일사합 (MJ/m2)"               )] public string SI_DAY            { get; set; }
        [Description("최대 1시간일사 (MJ/m2)"       )] public string SI_60M_MAX        { get; set; }
        [Description("최대 1시간일사 시각 (시분)"   )] public string SI_60M_MAX_TM     { get; set; }
        [Description("일 강수량 (mm)"               )] public string RN_DAY            { get; set; }
        [Description("9-9 강수량 (mm)"              )] public string RN_D99            { get; set; }
        [Description("강수계속시간 (hr)"            )] public string RN_DUR            { get; set; }
        [Description("1시간 최다강수량 (mm)"        )] public string RN_60M_MAX        { get; set; }
        [Description("1시간 최다강수량 시각 (시분)" )] public string RN_60M_MAX_TM     { get; set; }
        [Description("10분간 최다강수량 (mm)"       )] public string RN_10M_MAX        { get; set; }
        [Description("10분간 최다강수량 시각 (시분)")] public string RN_10M_MAX_TM     { get; set; }
        [Description("최대 강우강도 (mm/h)"         )] public string RN_POW_MAX        { get; set; }
        [Description("최대 강우강도 시각 (시분)"    )] public string RN_POW_MAX_TM     { get; set; }
        [Description("최심 신적설 (cm)"             )] public string SD_NEW            { get; set; }
        [Description("최심 신적설 시각 (시분)"      )] public string SD_NEW_TM         { get; set; }
        [Description("최심 적설 (cm)"               )] public string SD_MAX            { get; set; }
        [Description("최심 적설 시각 (시분)"        )] public string SD_MAX_TM         { get; set; }
        [Description("0.5m 지중온도 (C) "           )] public string TE_05             { get; set; }
        [Description("1.0m 지중온도 (C)"            )] public string TE_10             { get; set; }
        [Description("1.5m 지중온도 (C)"            )] public string TE_15             { get; set; }
        [Description("3.0m 지중온도 (C)"            )] public string TE_30             { get; set; }
        [Description("5.0m 지중온도 (C)"            )] public string TE_50             { get; set; }

        public TWeaterKMA_Response_Body()
        {
            Clear();
        }
        public void Clear()
        {
            TM              = string.Empty;
            STN             = string.Empty;
            WS_AVG          = string.Empty;
            WR_DAY          = string.Empty;
            WD_MAX          = string.Empty;
            WS_MAX          = string.Empty;
            WS_MAX_TM       = string.Empty;
            WD_INS          = string.Empty;
            WS_INS          = string.Empty;
            WS_INS_TM       = string.Empty;
            TA_AVG          = string.Empty;
            TA_MAX          = string.Empty;
            TA_MAX_TM       = string.Empty;
            TA_MIN          = string.Empty;
            TA_MIN_TM       = string.Empty;
            TD_AVG          = string.Empty;
            TS_AVG          = string.Empty;
            TG_MIN          = string.Empty;
            HM_AVG          = string.Empty;
            HM_MIN          = string.Empty;
            HM_MIN_TM       = string.Empty;
            PV_AVG          = string.Empty;
            EV_S            = string.Empty;
            EV_L            = string.Empty;
            FG_DUR          = string.Empty;
            PA_AVG          = string.Empty;
            PS_AVG          = string.Empty;
            PS_MAX          = string.Empty;
            PS_MAX_TM       = string.Empty;
            PS_MIN          = string.Empty;
            PS_MIN_TM       = string.Empty;
            CA_TOT          = string.Empty;
            SS_DAY          = string.Empty;
            SS_DUR          = string.Empty;
            SS_CMB          = string.Empty;
            SI_DAY          = string.Empty;
            SI_60M_MAX      = string.Empty;
            SI_60M_MAX_TM   = string.Empty;
            RN_DAY          = string.Empty;
            RN_D99          = string.Empty;
            RN_DUR          = string.Empty;
            RN_60M_MAX      = string.Empty;
            RN_60M_MAX_TM   = string.Empty;
            RN_10M_MAX      = string.Empty;
            RN_10M_MAX_TM   = string.Empty;
            RN_POW_MAX      = string.Empty;
            RN_POW_MAX_TM   = string.Empty;
            SD_NEW          = string.Empty;
            SD_NEW_TM       = string.Empty;
            SD_MAX          = string.Empty;
            SD_MAX_TM       = string.Empty;
            TE_05           = string.Empty;
            TE_10           = string.Empty;
            TE_15           = string.Empty;
            TE_30           = string.Empty;
            TE_50           = string.Empty;
        }

        public TWeaterKMA_Response_Body(string csvText)
            : this()
        {
            List<string> lines = csvText.SplitToLineListEx();
            foreach(var line in lines)
            {
                if (line != null && line.IsNullOrWhiteSpaceEx() != true && line.Trim().StartsWith(@"#") != true)
                {
                    this = TWeaterKMA_Response_Body.SetMatchValue(line);
                    return;
                }
                else
                {
                    //Clear();
                }
            }
        }

        public string GetMatchString()
        {

            return string.Join(",",
                TM, STN, WS_AVG, WR_DAY, WD_MAX, WS_MAX, WS_MAX_TM, WD_INS,
                WS_INS, WS_INS_TM, TA_AVG, TA_MAX, TA_MAX_TM, TA_MIN,
                TA_MIN_TM, TD_AVG, TS_AVG, TG_MIN, HM_AVG, HM_MIN,
                HM_MIN_TM, PV_AVG, EV_S, EV_L, FG_DUR, PA_AVG, PS_AVG,
                PS_MAX, PS_MAX_TM, PS_MIN, PS_MIN_TM, CA_TOT, SS_DAY,
                SS_DUR, SS_CMB, SI_DAY, SI_60M_MAX, SI_60M_MAX_TM,
                RN_DAY, RN_D99, RN_DUR, RN_60M_MAX, RN_60M_MAX_TM,
                RN_10M_MAX, RN_10M_MAX_TM, RN_POW_MAX, RN_POW_MAX_TM,
                SD_NEW, SD_NEW_TM, SD_MAX, SD_MAX_TM, TE_05, TE_10,
                TE_15, TE_30, TE_50
            );
        }
        public string GetPropertyString()
        {
            TWeaterKMA_Response_Body water = this;
            PropertyInfo[] props = typeof(TWeaterKMA_Response_Body).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            if (props == null || props.Length == 0) { return null; }

            string[] csv = new string[props.Length];
            var values = props.Select(prop => prop.GetValue(water)?.ToString() ?? "");

            return string.Join(",", values);
        }

        public static TWeaterKMA_Response_Body SetMatchValue(string csvLine)
        {
            string[] csv = csvLine.Split(',');

            // CSV 값 개수가 충분한지 간단히 확인
            if (csv.Length < 56)
            {
                throw new ArgumentException("Insufficient number of CSV data columns. (CSV 데이터 열 개수가 부족)");
            }

            TWeaterKMA_Response_Body Result = new()
            {
                TM = csv[0],
                STN = csv[1],
                WS_AVG = csv[2],
                WR_DAY = csv[3],
                WD_MAX = csv[4],
                WS_MAX = csv[5],
                WS_MAX_TM = csv[6],
                WD_INS = csv[7],
                WS_INS = csv[8],
                WS_INS_TM = csv[9],
                TA_AVG = csv[10],
                TA_MAX = csv[11],
                TA_MAX_TM = csv[12],
                TA_MIN = csv[13],
                TA_MIN_TM = csv[14],
                TD_AVG = csv[15],
                TS_AVG = csv[16],
                TG_MIN = csv[17],
                HM_AVG = csv[18],
                HM_MIN = csv[19],
                HM_MIN_TM = csv[20],
                PV_AVG = csv[21],
                EV_S = csv[22],
                EV_L = csv[23],
                FG_DUR = csv[24],
                PA_AVG = csv[25],
                PS_AVG = csv[26],
                PS_MAX = csv[27],
                PS_MAX_TM = csv[28],
                PS_MIN = csv[29],
                PS_MIN_TM = csv[30],
                CA_TOT = csv[31],
                SS_DAY = csv[32],
                SS_DUR = csv[33],
                SS_CMB = csv[34],
                SI_DAY = csv[35],
                SI_60M_MAX = csv[36],
                SI_60M_MAX_TM = csv[37],
                RN_DAY = csv[38],
                RN_D99 = csv[39],
                RN_DUR = csv[40],
                RN_60M_MAX = csv[41],
                RN_60M_MAX_TM = csv[42],
                RN_10M_MAX = csv[43],
                RN_10M_MAX_TM = csv[44],
                RN_POW_MAX = csv[45],
                RN_POW_MAX_TM = csv[46],
                SD_NEW = csv[47],
                SD_NEW_TM = csv[48],
                SD_MAX = csv[49],
                SD_MAX_TM = csv[50],
                TE_05 = csv[51],
                TE_10 = csv[52],
                TE_15 = csv[53],
                TE_30 = csv[54],
                TE_50 = csv[55] // 56번째 값 (인덱스 55)
            };

            return Result;
        }
        public static IEnumerable<TWeaterKMA_Response_Body> Load(string text)
        {
            string[] lines = text.Split(new char[] { '\r', '\n' } );
            if(lines == null || lines.Length == 0) { return [default]; }

            List<TWeaterKMA_Response_Body> Result = new List<TWeaterKMA_Response_Body>();
            for (int i = 0; i < lines.Length; i++) 
            {
                if(lines[i] == null || lines[i].IsNullOrWhiteSpaceEx()) { continue; }

                string line = lines[i];

                if (line.IsNullOrWhiteSpaceEx() == true || line.StartsWith(@"#") == true) { continue; }

                TWeaterKMA_Response_Body water = new TWeaterKMA_Response_Body(line);
                if(water.TM.IsNullOrWhiteSpaceEx() == true || water.STN.IsNullOrWhiteSpaceEx() == true) { continue; }

                Result.Add(water);
            }
            return Result?.ToArray();
        }
        public static TWeaterKMA_Response_Body SetPropertyValue(string csvLine)
        {
            string[] csv = csvLine.Split(',');
            
            PropertyInfo[] props = typeof(TWeaterKMA_Response_Body).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            if(props == null || props.Length == 0) { return default; }

            var Result = new TWeaterKMA_Response_Body();
            object data = Result;
            for (int i = 0; i < props.Length; i++)
            {
                if (i >= csv.Length) { break; }

                string strValue = (csv[i] ?? string.Empty).Trim();
                props[i].SetValue(data, strValue);
            }

            return (TWeaterKMA_Response_Body)data;
        }
        public static string ToMatchString(TWeaterKMA_Response_Body water)
        {
            return water.GetMatchString();
        }

        public static string ToPropertyString(TWeaterKMA_Response_Body water)
        {
            /*
            PropertyInfo[] props = typeof(TWaterTypeClassescs).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            if (props == null || props.Length == 0) { return null; }

            string[] csv = new string[props.Length];
            var values = props.Select(prop => prop.GetValue(water)?.ToString() ?? "");

            return string.Join(",", values);
            */
            return water.GetPropertyString();
        }
    }
}
