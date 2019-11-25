-- FRIEND_TB 작업 --


-- field 생성 --

-- 홍길동 친구 설정 --
insert into FRIEND_TB values('U100000', 'U100001', null); -- 김길동이랑 친구 --
insert into FRIEND_TB values('U100000', 'U100002', null); -- 최길동이랑 친구 --

-- 김길동 친구 설정 --
insert into FRIEND_TB values('U100001', 'U100002', null); -- 최길동이랑 친구 --

-- 최길동 친구 홍길동, 김길동 끝 --

-- 위길동 친구 없음 --

commit;