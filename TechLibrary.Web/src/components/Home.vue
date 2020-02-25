<template>
    <div class="home">
        <h1>{{ msg }}</h1>

        <b-input-group prepend="Search" class="mt-3">
            <b-form-input v-model="keyword"></b-form-input>
            <b-input-group-append>
                <b-button variant="info" v-on:click="searchBooks()">Search Books</b-button>
            </b-input-group-append>
        </b-input-group>
        <b-table id="bookList" :items="dataContext" :per-page="perPage" :current-page="currentPage" striped hover :fields="fields" responsive="sm">
            <template v-slot:cell(thumbnailUrl)="data">
                <b-img :src="data.value" thumbnail fluid></b-img>
            </template>
            <template v-slot:cell(title_link)="data">
                <b-link :to="{ name: 'book_view', params: { 'id' : data.item.bookId } }">{{ data.item.title }}</b-link>
            </template>
        </b-table>
        <b-pagination v-model="currentPage"
                      :total-rows=1000
                      :per-page="perPage"
                      aria-controls="bookList"></b-pagination>
        <!--<p class="mt-3">Current Page: {{ currentPage }}</p-->
    </div>
</template>

<script>
    import axios from 'axios';
    import { BTable } from 'bootstrap-vue';

    export default {
        name: 'Home',
        props: ["msg", "pageid"],

        data: () => ({
            fields: [

                { key: 'thumbnailUrl', label: 'Book Image' },
                { key: 'title_link', label: 'Book Title', sortable: true, sortDirection: 'desc' },
                { key: 'isbn', label: 'ISBN', sortable: true, sortDirection: 'desc' },
                { key: 'descr', label: 'Description', sortable: true, sortDirection: 'desc' }

            ],
            items: [],
            perPage: 10,
            currentPage: '1',
            keyword: '',
            bookList: BTable
        }),
        computed: {
            rows() {
                return this.items.length
            }
        },

        methods: {
            dataContext(ctx, callback) {

                axios.get(`https://localhost:5001/books/page/${this.currentPage}`)
                    .then(response => {

                        callback(response.data);
                    });
            },

            searchBooks: function () {
                axios.get(`https://localhost:5001/books/search/${this.keyword}`)
                    .then(function (response) {
                        this.bookList.items = response.data;
                    })

            }
        }
    };

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>

