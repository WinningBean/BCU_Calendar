-- insert시 앞글자 하나라면 100000 부터 시작 --
-- insert시 앞글자 두개라면 10000 부터 시작 --

-- 사용자 코드 시퀀스 --
create sequence seq_urcd
start with 100000
increment by 1;
-- insert 사용시 : 'U'||to_char(seq_urcd.NEXTVAL) --

-- 일정 코드 시퀀스 --
create sequence seq_sccd
start with 100000
increment by 1;
-- insert 사용시 : 'S'||to_char(seq_urcd.NEXTVAL) --

-- 사진 코드 시퀀스 --
create sequence seq_piccd
start with 100000
increment by 1;
-- insert 사용시 : 'P'||to_char(seq_urcd.NEXTVAL) --

-- 할 일 코드 시퀀스 --
create sequence seq_tdcd
start with 100000
increment by 1;
-- insert 사용시 : 'T'||to_char(seq_urcd.NEXTVAL) --

-- 그룹 코드 시퀀스 --
create sequence seq_grcd
start with 100000
increment by 1;
-- insert 사용시 : 'G'||to_char(seq_urcd.NEXTVAL) --

-- 친구그룹 코드 시퀀스 --
create sequence seq_frgrcd
start with 10000
increment by 1;
-- insert 사용시 : 'FG'||to_char(seq_urcd.NEXTVAL) --

-- 댓글 코드 시퀀스 --
create sequence seq_ctcd
start with 100000
increment by 1;
-- insert 사용시 : 'C'||to_char(seq_urcd.NEXTVAL) --

-- 컬러 코드 시퀀스 --
create sequence seq_crcd
start with 10000
increment by 1;
-- insert 사용시 : 'CR'||to_char(seq_urcd.NEXTVAL) --