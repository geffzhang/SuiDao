@echo off
color 0e
@echo ==================================
@echo ���ѣ����Ҽ����ļ����ù���Ա��ʽ�򿪡�
@echo ==================================
@echo Start Install SuiDao.Client

sc create SuiDao.Client binPath=%~dp0\SuiDao.Client.exe start= auto 
sc description SuiDao.Client "FastTunnel-��Դ������͸���񣬲ֿ��ַ��https://github.com/SpringHgui/FastTunnel"
Net Start SuiDao.Client
pause