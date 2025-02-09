<template>
    <div class="accordion" id="accordionHistory">
        <div class="accordion-item">
            <h2 class="accordion-header" id="accordeonHistory">
                <button class="accordion-button text-center collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseHistory" aria-expanded="false" aria-controls="collapseHistory">
                    History
                </button>
            </h2>
            <div id="collapseHistory" class="accordion-collapse collapse" aria-labelledby="accordeonHistory" data-bs-parent="#accordionHistory">
                <div class="accordion-body">
                    <table class="table table-responsive text-center">
                        <tbody>
                            <tr>
                                <th>ID</th>
                                <th>Name</th>
                                <th>Content</th>
                                <th>Date Published</th>
                                <th width="100px"></th>
                            </tr>
                            <tr v-for="(post, index) in posts" :key="index">
                                <td>{{ post.id }}</td>
                                <td>{{ post.name }}</td>
                                <td v-html="post.content.substring(0, 80)"></td>
                                <td>{{ moment(post.datePublished).format('LL') }}</td>
                                <td class="text-right" width="100px">
                                    <button @click="this.delete(post.id)" class="btn btn-danger"><i class="bi bi-x-circle-fill"></i></button>
                                    <button @click="fill(post.id)" class="btn btn-info"><i class="bi bi-arrow-up-square-fill"></i></button>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</template>
<script lang="js">
import moment from 'moment';

export default {
    data() {
        return {
            moment: moment,
            posts: []
        }
    },
    async mounted() {
        await this.refresh();
    },
    methods: {
        async refresh() {
            this.posts = await (await fetch('Posts/GetByProjectId?projectId=' + this.project)).json();
        },
        async delete(postId) {
            await fetch(`Posts/Delete?id=${postId}`, { method: 'DELETE' });
            await this.refresh();
        },
        fill(postId) {
            const postToEdit = this.posts.find(post => post.id === postId);
            if (postToEdit) {
                this.populateEditForm(postToEdit);
            }
        },
        populateEditForm(post) {
            this.title = post.name;
            this.content = post.content;
            this.datePublished = post.datePublished;
        }
    },
    props: {
        watch: {
            project: 'refresh',
            postType: 'refresh'
        },
        project: Number,
        postType: Number,
        watch: {
            project(newVal) {
                this.refresh();
            },
            postType(newVal) {
                this.refresh();
            }
        }
    },
    watch: {
        project(newVal) {
            this.refresh();
        },
        postType(newVal) {
            this.refresh();
        }
    }
}
</script>
<style scoped>
</style>