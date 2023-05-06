<template>
    <div class="evnt" v-for="event in events" :key="event.id">
        <div class="evntTitle"><strong>Title: </strong>{{ event.title }}</div>
        <div class="evntContent"><strong>Description: </strong>{{ event.description }}</div>
        <div class="evntDate1">
            <strong>Start date: </strong>
            {{
                `${new Date(event.startDate).toLocaleDateString('uk-UA')}`
            }}
        </div>
        <div class="evntDate2">
            <strong>End date: </strong>
            {{ `${new Date(event.endDate).toLocaleDateString('uk-UA')}` }}
        </div>
        <div class="read">
            <button class="link" @click="getEvent(event.id)">Read</button>
        </div>
    </div>
    <div class="page__wrapper">
        <div v-for="pageNumber in totalPages" :key="pageNumber" class="page" :class="{
            'current-page': page === pageNumber
        }" @click="changePage(pageNumber)">{{ pageNumber }}</div>
    </div>
</template>

<script>
import router from '@/router';
import axios from 'axios';
export default {
    data() {
        return {
            events: [],
            page: 1,
            limit: 5,
            totalPages: 0
        }
    },
    methods: {
        changePage(pageNumber) {
            this.page = pageNumber;
            this.getEvents({ page: pageNumber - 1, limit: this.limit });
        },
        getEvents(params) {
            try {
                axios.get('https://localhost:7219/Event', { params })
                    .then((res) => {
                        this.events = res.data.item1;
                        this.totalPages = Math.ceil(res.data.item2 / this.limit);
                    })
                    .catch((err) => console.log(err));
            } catch (err) {
                console.log(err);
            }
        },
        getEvent(id) {
            try {
                localStorage.setItem('eventId', id);
                router.push('/event');
            } catch (err) {
                console.log(err);
            }
        }
    },
    mounted() {
        this.getEvents();
    }
}
</script>

<style>
.evnt {
    border-radius: 15px;
    margin-top: 15px;
    margin-left: 225px;
    font-size: 20px;
    width: 900px;
    padding: 15px;
    padding-top: 15px;
    background: rgba(0, 0, 0, 0.3);
    color: white;
    border: 2px solid white;
}

.evntContent, .evntDate1, .evntDate2 {
    padding-top: 10px;
}
</style>
