-- USER_TB 작업 --

-- field 추가 --
insert into USER_TB values('U'||to_char(seq_urcd.NEXTVAL), 'testuser1', '1234', '홍길동');
insert into USER_TB values('U'||to_char(seq_urcd.NEXTVAL), 'testuser2', '1234', '김길동');
insert into USER_TB values('U'||to_char(seq_urcd.NEXTVAL), 'testuser3', '1234', '최길동');
insert into USER_TB values('U'||to_char(seq_urcd.NEXTVAL), 'testuser4', '1234', '위길동');