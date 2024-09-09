<template>
    <div>
        <hgroup>
            <h3 class="text-center">Tweet</h3>
        </hgroup>
        <div class="form-group">
            <label for="postDescription">Content</label>
            <textarea id="postDescription" class="form-control" placeholder="Description" aria-describedby="postDescription" v-model="postDescription"></textarea>
        </div>
        <button @click="publish" class="btn btn-primary text-center">Publish</button>
    </div>
</template>
<script lang="js">
export default {
    data() {
        return {
            postDescription: ''
        }
    },
    methods: {
        async publish() {
            let platforms = []; 
            let platfromsDom = document.querySelectorAll('.platform:checked');
            for(let i = 0; i < platfromsDom.length; i++) {
                platforms.push(platfromsDom[i].value);
            }
            const data = JSON.stringify({
                ProjectId: Number(document.getElementById('ddlProject').value),
                Type: Number(document.getElementById('ddlPostType').value),
                Platforms: platforms,
                Description: this.postDescription
            });
            const requestOptions = {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: data
            };
            const result = await fetch('Publish/PublishTweet', requestOptions);
        }
    }
}
</script>