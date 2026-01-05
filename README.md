# TxFarmDiary  
## AI-OCR을 활용한 영농일지 자동화 시스템 설계 및 구현  
**Farming Diary Automation System Design & Implementation with AI-OCR**

---

## 📌 프로젝트 개요 (Overview)

본 저장소는  
**「AI-OCR을 활용한 영농일지 자동화 시스템 설계 및 구현」**  
석사학위 논문 연구 과정에서 **설계·구현한 실제 시스템 코드**를 공개하기 위한 목적의 저장소입니다.

본 연구는 **농업 현장의 수기(필기) 기반 영농일지**를 유지하면서,  
AI-OCR(Artificial Intelligence – Optical Character Recognition, 인공지능 광학 문자 인식) 기술을 활용하여  
**자동으로 디지털화·구조화·저장**할 수 있는 시스템을 설계·구현하는 것을 목표로 합니다.

> ✍️ *“종이 기반 필기의 편의성 + 디지털 데이터의 활용성”을 동시에 확보*  

---

## 🎓 학위 논문 정보 (Thesis Information)

- **논문 제목**  
  AI-OCR을 활용한 영농일지 자동화 시스템 설계 및 구현  
  (Farming Diary Automation System Design & Implementation with AI-OCR)

- **저자**  
  박주현 (Park, Ju-Hyun)

- **소속**  
  국립순천대학교 > 일반대학원 > 스마트융합학부 > 스마트농업전공

- **지도교수**  
  조용윤 교수

- **학위**  
  공학석사

- **년월**  
  2026.02

---

## 📂 저장소 구성 (Repository Structure)

```text
TxFarmDiary
 ├─ TxFarmDiaryAI.Core      # 공통 코어 라이브러리 (Class Library)
 ├─ TxFarmDiaryAI.Web       # 백엔드 Web-API (ASP.NET Core)
 ├─ TxFarmDiaryAI.Win       # Windows Desktop Application (C#)
 └─ README.md
```

---

## 🧩 시스템 아키텍처 개요 (System Architecture)
본 시스템은 다음과 같은 구조로 설계·구현되었습니다.

- **Frontend** 
  - Windows Desktop Application (C#, .NET)
  - 스캐너(WIA), 카메라, 이미지 파일 입력 지원

- **Backend**
  - ASP.NET Core Web-API
  - JSON 기반 데이터 교환

- **AI-OCR**
  - Naver CLOVA OCR (Template / Key-Value 기반)

- **기상 API**
  - 기상청 API허브 (공공데이터, Weather API)

- **Database**
  - Oracle Database

---

## 🔗 관련 링크 (Related Links)

- **GitHub (본 저장소)**
  https://github.com/userjhpark/TxFarmDiary

- **공통 라이브러리 (HxCore)**
  https://github.com/userjhpark/HxCore

- **Naver CLOVA OCR 공식 문서**
  https://guide.ncloud-docs.com/docs/clovaocr-overview

- **기상청 API 허브**
  https://apihub.kma.go.kr/apiInfo.do
  
---

**박주현. (2026). AI-OCR을 활용한 영농일지 자동화 시스템 설계 및 구현. 공학석사 학위논문, 국립순천대학교 일반대학원.**

**Park, Ju-Hyun. (2026). Farming Diary Automation System Design & Implementation with AI-OCR. Master’s Thesis, Sunchon National University.**
