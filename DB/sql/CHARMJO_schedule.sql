-- SCHEDULE_TB 작업 --

-- field 생성 --

-- 홍길동 스케줄 --
insert into SCHEDULE_TB values('S'||to_char(seq_sccd.NEXTVAL),'일정1', '일정1을 생성하였습니다.', 1, to_date('2019/11/11 11:00','yyyy/mm/dd hh24:mi'), to_date('2019/11/11 13:00','yyyy/mm/dd hh24:mi'), null, null, 'U100000', null); 
-- 하루종일의 경우 --
insert into SCHEDULE_TB values('S'||to_char(seq_sccd.NEXTVAL),'일정2', '일정2을 생성하였습니다.', 1, to_date('2019/11/12 00:00','yyyy/mm/dd hh24:mi'), to_date('2019/11/12 23:59','yyyy/mm/dd hh24:mi'), null, null, 'U100000', null);
-- 비공개의 경우 --
insert into SCHEDULE_TB values('S'||to_char(seq_sccd.NEXTVAL),'일정3', '일정3을 생성하였습니다.', 0, to_date('2019/11/13 20:00','yyyy/mm/dd hh24:mi'), to_date('2019/11/13 21:00','yyyy/mm/dd hh24:mi'), null, null, 'U100000', null);
-- 이틀 하루종일의 경우, 다른 일정과 겹치는 경우 --
insert into SCHEDULE_TB values('S'||to_char(seq_sccd.NEXTVAL),'일정4', '일정4을 생성하였습니다.', 1, to_date('2019/11/13 00:00','yyyy/mm/dd hh24:mi'), to_date('2019/11/13 23:00','yyyy/mm/dd hh24:mi'), null, null, 'U100000', null);
-- 비공개, 일정내용이 없는 경우
insert into SCHEDULE_TB values('S'||to_char(seq_sccd.NEXTVAL),'일정5', null, 0, to_date('2019/11/15 12:00','yyyy/mm/dd hh24:mi'), to_date('2019/11/15 18:00','yyyy/mm/dd hh24:mi'), null, null, 'U100000', null);

-- 김길동 스케줄 --
insert into SCHEDULE_TB values('S'||to_char(seq_sccd.NEXTVAL),'일정1', '일정1을 생성하였습니다.', 1, to_date('2019/11/11 11:00','yyyy/mm/dd hh24:mi'), to_date('2019/11/11 13:00','yyyy/mm/dd hh24:mi'), null, null, 'U100001', null); 
-- 하루종일의 경우 --
insert into SCHEDULE_TB values('S'||to_char(seq_sccd.NEXTVAL),'일정2', '일정2을 생성하였습니다.', 1, to_date('2019/11/12 00:00','yyyy/mm/dd hh24:mi'), to_date('2019/11/12 23:59','yyyy/mm/dd hh24:mi'), null, null, 'U100001', null);
-- 비공개의 경우 --
insert into SCHEDULE_TB values('S'||to_char(seq_sccd.NEXTVAL),'일정3', '일정3을 생성하였습니다.', 0, to_date('2019/11/13 20:00','yyyy/mm/dd hh24:mi'), to_date('2019/11/13 21:00','yyyy/mm/dd hh24:mi'), null, null, 'U100001', null);
-- 이틀 하루종일의 경우, 다른 일정과 겹치는 경우 --
insert into SCHEDULE_TB values('S'||to_char(seq_sccd.NEXTVAL),'일정4', '일정4을 생성하였습니다.', 1, to_date('2019/11/13 00:00','yyyy/mm/dd hh24:mi'), to_date('2019/11/13 23:00','yyyy/mm/dd hh24:mi'), null, null, 'U100001', null);
-- 비공개, 일정내용이 없는 경우
insert into SCHEDULE_TB values('S'||to_char(seq_sccd.NEXTVAL),'일정5', null, 0, to_date('2019/11/15 12:00','yyyy/mm/dd hh24:mi'), to_date('2019/11/15 18:00','yyyy/mm/dd hh24:mi'), null, null, 'U100001', null);

-- 최길동 스케줄 --
insert into SCHEDULE_TB values('S'||to_char(seq_sccd.NEXTVAL),'일정1', '일정1을 생성하였습니다.', 1, to_date('2019/11/11 11:00','yyyy/mm/dd hh24:mi'), to_date('2019/11/11 13:00','yyyy/mm/dd hh24:mi'), null, null, 'U100002', null); 
-- 하루종일의 경우 --
insert into SCHEDULE_TB values('S'||to_char(seq_sccd.NEXTVAL),'일정2', '일정2을 생성하였습니다.', 1, to_date('2019/11/12 00:00','yyyy/mm/dd hh24:mi'), to_date('2019/11/12 23:59','yyyy/mm/dd hh24:mi'), null, null, 'U100002', null);
-- 비공개의 경우 --
insert into SCHEDULE_TB values('S'||to_char(seq_sccd.NEXTVAL),'일정3', '일정3을 생성하였습니다.', 0, to_date('2019/11/13 20:00','yyyy/mm/dd hh24:mi'), to_date('2019/11/13 21:00','yyyy/mm/dd hh24:mi'), null, null, 'U100002', null);
-- 이틀 하루종일의 경우, 다른 일정과 겹치는 경우 --
insert into SCHEDULE_TB values('S'||to_char(seq_sccd.NEXTVAL),'일정4', '일정4을 생성하였습니다.', 1, to_date('2019/11/13 00:00','yyyy/mm/dd hh24:mi'), to_date('2019/11/13 23:00','yyyy/mm/dd hh24:mi'), null, null, 'U100002', null);
-- 비공개, 일정내용이 없는 경우
insert into SCHEDULE_TB values('S'||to_char(seq_sccd.NEXTVAL),'일정5', null, 0, to_date('2019/11/15 12:00','yyyy/mm/dd hh24:mi'), to_date('2019/11/15 18:00','yyyy/mm/dd hh24:mi'), null, null, 'U100002', null);

-- 위길동 스케줄 --
insert into SCHEDULE_TB values('S'||to_char(seq_sccd.NEXTVAL),'일정1', '일정1을 생성하였습니다.', 1, to_date('2019/11/11 11:00','yyyy/mm/dd hh24:mi'), to_date('2019/11/11 13:00','yyyy/mm/dd hh24:mi'), null, null, 'U100003', null); 
-- 하루종일의 경우 --
insert into SCHEDULE_TB values('S'||to_char(seq_sccd.NEXTVAL),'일정2', '일정2을 생성하였습니다.', 1, to_date('2019/11/12 00:00','yyyy/mm/dd hh24:mi'), to_date('2019/11/12 23:59','yyyy/mm/dd hh24:mi'), null, null, 'U100003', null);
-- 비공개의 경우 --
insert into SCHEDULE_TB values('S'||to_char(seq_sccd.NEXTVAL),'일정3', '일정3을 생성하였습니다.', 0, to_date('2019/11/13 20:00','yyyy/mm/dd hh24:mi'), to_date('2019/11/13 21:00','yyyy/mm/dd hh24:mi'), null, null, 'U100003', null);
-- 이틀 하루종일의 경우, 다른 일정과 겹치는 경우 --
insert into SCHEDULE_TB values('S'||to_char(seq_sccd.NEXTVAL),'일정4', '일정4을 생성하였습니다.', 1, to_date('2019/11/13 00:00','yyyy/mm/dd hh24:mi'), to_date('2019/11/13 23:00','yyyy/mm/dd hh24:mi'), null, null, 'U100003', null);
-- 비공개, 일정내용이 없는 경우
insert into SCHEDULE_TB values('S'||to_char(seq_sccd.NEXTVAL),'일정5', null, 0, to_date('2019/11/15 12:00','yyyy/mm/dd hh24:mi'), to_date('2019/11/15 18:00','yyyy/mm/dd hh24:mi'), null, null, 'U100003', null);
