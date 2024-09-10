<template>
    <div class="form-group">
        <label for="postDescription">Description</label>
        <textarea id="postDescription" class="form-control" placeholder="Description" aria-describedby="postDescription" v-model="postDescription"></textarea>
    </div>
    <br />
    <div class="custom-file mt-3 mb-3">
        <input type="file" class="custom-file-input" id="short" style="border: 1px solid black" />
    </div>
    <div class="form-group">
        <button @click="publish" class="btn btn-success text-center">Publish</button>
    </div>
</template>
<script lang="js">
export default {
    data() {
        return {
            postDescription: '',
            postShort: []
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
                PostDescription: this.postDescription,
                PostShort: this.postShort
            });
            const requestOptions = {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: data
            };
            const result = await fetch('Publish/PublishShort', requestOptions);
        }
    },
    props: {
        project: Number,
        postType: Number
    }
}
</script>