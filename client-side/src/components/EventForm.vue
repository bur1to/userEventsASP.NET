<template>
    <div class="eventForm">
        <div class="event">
            <form @submit.prevent>
                <h4 class="ttl">Create event</h4>
                <input v-model="event.title" class="input" type="text" placeholder="Name of event">
                <textarea v-model="event.description" placeholder="Event plans" class="textArea"></textarea>
                <input v-model="event.startDate" class="input" type="date">
                <input v-model="event.endDate" class="input" type="date">
                <div class="createEvent">
                    <button @click="createEvent" class="btn10">Create event</button>
                </div>
            </form>
        </div>
    </div>
</template>

<script>
import router from '@/router';
import axios from 'axios'
export default {
    data() {
        return {
            event: {
                userId: localStorage.getItem('id'),
                title: '',
                description: '',
                startDate: '',
                endDate: ''
            }
        }
    },
    methods: {
        async createEvent() {
            try {
                await axios.post('https://localhost:7219/Event', this.event)
                    .then((res) => console.log(res))
                    .catch((err) => console.log(err));
                this.$emit('create', this.event);
                this.$event = {
                    userId: '',
                    title: '',
                    description: '',
                    startDate: '',
                    endDate: ''
                };
                router.push('/profile');
            } catch (err) {
                console.log(err);
            }
        }
    }
}
</script>

<style>
.eventForm {
    display: flex;
    justify-content: center;
    margin-top: 55px;
    margin-left: 35px;
    color: white;
}

form {
    display: flex;
    flex-direction: column;
}

.ttl {
    text-align: center;
}

.textArea {
    margin-top: 15px;
    border: 2px solid teal;
    border-radius: 5px;
    height: 100px;
    padding: 7px;
}

.createEvent {
    margin-top: 10px;
}

.btn10 {
    font-size: 20px;
    border-radius: 15px;
    padding: 3px 11px 3px 11px;
    background: none;
    color: white;
    border: 2px solid white;
}

.btn10:hover {
    background: white;
    color: black;
}

.event {
    background: rgba(0, 0, 0, 0.3);
    width: 400px;
    padding: 20px;
    border-radius: 20px;
    border: 2px solid white;
}

.input {
    width: 300px;
    border: 1px solid teal;
    padding: 10px 15px;
    margin-top: 15px;
}
</style>