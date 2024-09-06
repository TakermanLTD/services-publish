<template>
    <div>
        <hgroup>
            <h3 class="text-center">PUBLICATION</h3>
        </hgroup>
        <div class="form-group">
            <label for="postName">Name</label>
            <input
                   type="text"
                   name="postName"
                   id="postName"
                   class="form-control"
                   placeholder="Name"
                   aria-describedby="postName"
                   v-model="postName" />
            <small id="postName" class="text-muted">Put the item name here</small>
        </div>
        <br />
        <div class="form-group">
            <label for="postDescription">Description</label>
            <textarea
                      name="postDescription"
                      id="postDescription"
                      class="form-control"
                      placeholder="Description"
                      aria-describedby="postDescription"
                      v-model="postDescription"></textarea>
            <small id="postDescription" class="text-muted">Put the description here</small>
        </div>
        <br />
        <div v-if="this.postType == 0" class="form-group">
            <label for="postPrice">Price</label>
            <input
                   name="postPrice"
                   id="postPrice"
                   class="form-control"
                   placeholder="Price"
                   aria-describedby="postPrice"
                   v-model="postPrice"></input>
            <small id="postPrice" class="text-muted">Put the price here</small>
        </div>
        <br />
        <div class="custom-file mt-3 mb-3">
            <input
                   type="file"
                   class="custom-file-input"
                   id="pictures"
                   style="border: 1px solid black" />
            <br />
            <label class="custom-file-label" for="pictures">Upload pictures</label>
        </div>
        <button @click="publish" class="btn btn-primary text-center">Publish</button>
    </div>
</template>
<script lang="js">
export default {
    data() {
        return {
            postName: '',
            postDescription: '',
            postPrice: 0,
            postPictures: []
        }
    },
    methods: {
        async publish() {
            const data = JSON.stringify({
                Type: this.postType,
                Platforms: this.postPlatforms,
                Name: this.postName,
                Description: this.postDescription,
                Price: this.postPrice,
                Pictures: this.postPictures
            });
            const requestOptions = {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: data
            };
            const result = await fetch('Publish/PublishPost', requestOptions);
        }
    }
}
</script>