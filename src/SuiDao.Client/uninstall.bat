@echo off
color 0e
@echo ==================================
@echo ���ѣ����Ҽ����ļ����ù���Ա��ʽ�򿪡�
@echo ==================================
@echo Start Remove SuiDao.Client

Net stop SuiDao.Client
sc delete SuiDao.Client
pause