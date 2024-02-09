import http from 'k6/http';
import { sleep } from 'k6';
export default function () {
    http.get('http://localhost:8080/Delivery/Avaiable');

    sleep(1);
}

export let options = {
    thresholds: {
        http_req_duration: ['p(99)<10000'], 
    },
};
