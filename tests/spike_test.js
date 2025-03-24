import http from 'k6/http';
import { check, sleep } from 'k6';

export let options = {
    stages: [
        { duration: '10s', target: 100 },
        { duration: '1m', target: 100 },
        { duration: '10s', target: 500 },
        { duration: '3m', target: 500 },
        { duration: '10s', target: 100 },
        { duration: '3m', target: 100 },
        { duration: '10s', target: 0 },
    ],
};

export default function () {
    let res = http.get('http://localhost:8080/api/add?a=5&b=3');
    check(res, { 'status is 200': (r) => r.status === 200 });
    sleep(1);
}