<template>
    <div class="form-group">
        <label for="postName">Name</label>
        <input type="text" id="postName" class="form-control" placeholder="Name" aria-describedby="postName" v-model="postName" />
    </div>
    <br />
    <div class="form-group">
        <label for="postDescription">Content</label>
        <textarea id="postDescription" class="form-control" placeholder="Description" aria-describedby="postDescription" v-model="postDescription"></textarea>
    </div>
    <div class="form-group">
        <button @click="publish" class="btn btn-success text-center">Publish</button>
    </div>
</template>
<script lang="js">
export default {
    data() {
        return {
            postName: '',
            postDescription: ''
        }
    },
    methods: {
        async publish() {
            let platforms = [];
            let platfromsDom = document.querySelectorAll('.platform:checked');
            for (let i = 0; i < platfromsDom.length; i++) {
                platforms.push(Number(platfromsDom[i].value));
            }
            const data = JSON.stringify({
                Project: this.project,
                Type: this.postType,
                Platforms: platforms,
                PostName: this.postName,
                PostDescription: this.postDescription
            });
            const requestOptions = {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: data
            };
            const result = await fetch('Publish/PublishBlogpost', requestOptions);
        }
    },
    props: {
        project: Number,
        postType: Number
    }
}
</script>