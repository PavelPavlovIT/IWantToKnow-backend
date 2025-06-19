up:
	docker compose -f 'docker-compose.yml' up

up-debug:
	docker compose -f 'docker-compose.debug.yml' up

down:
	docker compose down

restart:
	docker compose restart
