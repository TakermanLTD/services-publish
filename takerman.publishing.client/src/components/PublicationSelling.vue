<template>
    <div class="form-group">
        <label for="postName">Name</label>
        <input type="text" id="postName" class="form-control" placeholder="Name" aria-describedby="postName" v-model="postName" />
    </div>
    <br />
    <div class="form-group">
        <label for="postDescription">Description</label>
        <textarea id="postDescription" class="form-control" placeholder="Description" aria-describedby="postDescription" v-model="postDescription"></textarea>
    </div>
    <br />
    <div class="form-group">
        <label for="postPrice">Price</label>
        <input id="postPrice" class="form-control" placeholder="Price" aria-describedby="postPrice" v-model="postPrice"></input>
    </div>
    <br />
    <div class="custom-file mt-3 mb-3">
        <input type="file" class="custom-file-input" id="pictures" style="border: 1px solid black" />
    </div>
    <br />
    <div class="custom-file mt-3 mb-3">
        <input type="file" class="custom-file-input" id="videos" style="border: 1px solid black" />
    </div>
    <button @click="publish" class="btn btn-success text-center">Publish</button>
</template>
<script lang="js">
export default {
    data() {
        return {
            postName: '',
            postDescription: '',
            postPrice: 0,
            postPictures: [],
            postVideos: []
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
                ProjectId: this.projectId,
                Type: this.postType,
                Platforms: platforms,
                PostName: this.postName,
                PostDescription: this.postDescription,
                PostPrice: this.postPrice,
                PostPictures: this.postPictures,
                PostVideos: this.postVideos
            });
            const requestOptions = {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: data
            };
            const result = await fetch('Publish/PublishSelling', requestOptions);
        }
    },
    props: {
        projectId: Number,
        postType: Number
    }
}
</script>